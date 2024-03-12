using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Roles
{
    public class CreateModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly SEP_ManagementContext _context;

        public CreateModel(RoleManager<Role> roleManager, SEP_ManagementContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }

        public IActionResult OnGet()
        {
            var settingGroupValues = Enum.GetValues(typeof(SettingGroup))
                                .Cast<SettingGroup>()
                                .Select(s => new SelectListItem
                                {
                                    Value = ((int)s).ToString(),
                                    Text = Enum.GetName(typeof(SettingGroup), s)
                                });
            ViewData["settingGroupValues"] = new SelectList(settingGroupValues, "Value", "Text");
            ViewData["ActiveList"] = new SelectList(ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList(), "ActiveKey", "DisplayActiveName");
            return Page();
        }

        [BindProperty]
        public Role Role { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _roleManager.Roles == null || Role == null)
            {
                var settingGroupValues = Enum.GetValues(typeof(SettingGroup))
                                .Cast<SettingGroup>()
                                .Select(s => new SelectListItem
                                {
                                    Value = ((int)s).ToString(),
                                    Text = Enum.GetName(typeof(SettingGroup), s)
                                });
                ViewData["settingGroupValues"] = new SelectList(settingGroupValues, "Value", "Text");
                ViewData["ActiveList"] = new SelectList(ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList(), "ActiveKey", "DisplayActiveName");
                return Page();
            }
            var checkRoleName = _context.Roles.FirstOrDefault(x => x.Name.Trim().ToUpper().Equals(Role.Name.Trim().ToUpper()));
            if (checkRoleName != null)
            {
                var settingGroupValues = Enum.GetValues(typeof(SettingGroup))
                                .Cast<SettingGroup>()
                                .Select(s => new SelectListItem
                                {
                                    Value = ((int)s).ToString(),
                                    Text = Enum.GetName(typeof(SettingGroup), s)
                                });
                ViewData["settingGroupValues"] = new SelectList(settingGroupValues, "Value", "Text");
                ViewData["ActiveList"] = new SelectList(ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList(), "ActiveKey", "DisplayActiveName");
                return Page();
            }
            await _roleManager.CreateAsync(Role);

            return RedirectToPage("./Index");
        }
    }
}
