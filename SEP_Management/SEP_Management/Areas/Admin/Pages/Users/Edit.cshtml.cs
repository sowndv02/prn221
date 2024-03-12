using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["StatusActive"] = new SelectList(ActiveEnum.GetListActive(), "ActiveKey", "DisplayActiveName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            User.Role = _context.Roles.SingleOrDefault(x => x.Id.Equals(User.RoleId));
            if (!ModelState.IsValid)
            {
                //foreach (var key in ModelState.Keys)
                //{
                //    var errors = ModelState[key].Errors;
                //    foreach (var error in errors)
                //    {
                //        await Console.Out.WriteLineAsync(error.ErrorMessage);
                //    }
                //}
                return Page();
            }

            var checkEmail = _context.Users.SingleOrDefault(x => x.Email.ToUpper().Equals(User.Email.ToUpper()));
            var checkPhone = _context.Users.SingleOrDefault(x => x.PhoneNumber.Equals(User.PhoneNumber));
            if ((checkEmail != null && !(checkEmail.Id.Equals(User.Id))) || (checkPhone != null && !(checkPhone.Id.Equals(User.Id))))
            {
                return Page();
            }
            var user = _context.Users.SingleOrDefault(x => x.Id == User.Id);
            user.FullName = User.FullName;
            user.Email = User.Email;
            user.RoleId = User.RoleId;
            user.PhoneNumber = User.PhoneNumber;
            user.Note = User.Note;
            //_context.Attach(User).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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


        public async Task<IActionResult> OnGetChangeStatusAsync(string status, string id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            User = user;
            if (status.ToUpper().Equals("InActive".ToUpper()))
            {
                User.IsActive = 1;
            }
            else if (status.ToUpper().Equals("Active".ToUpper()))
            {
                User.IsActive = 0;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
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

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
