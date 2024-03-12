using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SEP_ManagementContext _context;

        public CreateModel(UserManager<User> userManager, RoleManager<Role> roleManager, SEP_ManagementContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult OnGet()
        {
            ViewData["RoleId"] = new SelectList(_roleManager.Roles, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _userManager.Users == null || User == null)
            {
                ViewData["RoleId"] = new SelectList(_roleManager.Roles, "Id", "Name");
                return Page();
            }
            var checkEmail = await _context.Users.FirstOrDefaultAsync(x => x.Email.Trim().ToUpper().Equals(User.Email.Trim().ToUpper()));
            var checkPhone = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber.Trim().Equals(User.Email.Trim()));
            if (checkEmail != null || checkPhone != null)
            {
                ViewData["RoleId"] = new SelectList(_roleManager.Roles, "Id", "Name");
                return Page();
            }

            User.IsActive = 1;
            User.LockoutEnabled = true;
            await _userManager.CreateAsync(User);

            return RedirectToPage("./Index");
        }
    }
}
