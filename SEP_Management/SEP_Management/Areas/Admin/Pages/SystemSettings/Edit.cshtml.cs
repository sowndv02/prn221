using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Roles
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Role Role { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }
            var settingGroupValues = Enum.GetValues(typeof(SettingGroup))
                                .Cast<SettingGroup>()
                                .Select(s => new SelectListItem
                                {
                                    Value = ((int)s).ToString(),
                                    Text = Enum.GetName(typeof(SettingGroup), s)
                                });
            ViewData["settingGroupValues"] = new SelectList(settingGroupValues, "Value", "Text");
            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            ViewData["StatusActive"] = new SelectList(ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList(), "ActiveKey", "DisplayActiveName");
            Role = role;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var checkRoleName = await _context.Roles.FirstOrDefaultAsync(r => r.Name == Role.Name);
            if (checkRoleName != null && !checkRoleName.Id.Equals(Role.Id))
            {
                return Page();
            }
            var role = await _context.Roles.SingleOrDefaultAsync(r => r.Id == Role.Id);
            role.Name = Role.Name;
            role.Description = Role.Description;
            role.Group = Role.Group;

            //_context.Attach(Role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoleExists(string id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> OnGetChangeStatusAsync(string status, string id)
        {
            if (id == null || _context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            Role = role;
            if (status.ToUpper().Equals("InActive".ToUpper()))
            {
                Role.IsActive = 1;
            }
            else if (status.ToUpper().Equals("Active".ToUpper()))
            {
                Role.IsActive = 0;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(Role.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
