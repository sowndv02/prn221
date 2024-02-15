using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace SEP_Management.Areas.Admin.Pages.Role
{
    public class AddModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            public string ID { set; get; }

            [Required]
            [Display]
            [StringLength(100, MinimumLength = 3)]
            public string Name { set; get; }

        }

        [BindProperty]
        public InputModel Input { set; get; }

        [BindProperty]
        public bool IsUpdate { set; get; }

        public IActionResult OnGet() => NotFound("Not Found!");
        public IActionResult OnPost() => NotFound("Not Found!");


        public IActionResult OnPostStartNewRole()
        {
            StatusMessage = "Please enter information to create a new role";
            IsUpdate = false;
            ModelState.Clear();
            return Page();
        }

        public async Task<IActionResult> OnPostStartUpdate()
        {
            StatusMessage = null;
            IsUpdate = true;
            if (Input.ID == null)
            {
                StatusMessage = "Error: There is no information about Role";
                return Page();
            }
            var result = await _roleManager.FindByIdAsync(Input.ID);
            if (result != null)
            {
                Input.Name = result.Name;
                ViewData["Title"] = "Update role : " + Input.Name;
                ModelState.Clear();
            }
            else
            {
                StatusMessage = "Error: There is no information about Role ID = " + Input.ID;
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAddOrUpdate()
        {

            if (!ModelState.IsValid)
            {
                StatusMessage = null;
                return Page();
            }

            if (IsUpdate)
            {
                if (Input.ID == null)
                {
                    ModelState.Clear();
                    StatusMessage = "Error: There is no information about the role";
                    return Page();
                }
                var result = await _roleManager.FindByIdAsync(Input.ID);
                if (result != null)
                {
                    result.Name = Input.Name;
                    var roleUpdateRs = await _roleManager.UpdateAsync(result);
                    if (roleUpdateRs.Succeeded)
                    {
                        StatusMessage = "Updated successfully";
                    }
                    else
                    {
                        StatusMessage = "Error: ";
                        foreach (var er in roleUpdateRs.Errors)
                        {
                            StatusMessage += er.Description;
                        }
                    }
                }
                else
                {
                    StatusMessage = "Error: No updated Role found";
                }

            }
            else
            {
                var newRole = new IdentityRole(Input.Name);
                var rsNewRole = await _roleManager.CreateAsync(newRole);
                if (rsNewRole.Succeeded)
                {
                    StatusMessage = $"Created successfully: {newRole.Name}";
                    return RedirectToPage("./Index");
                }
                else
                {
                    StatusMessage = "Error: ";
                    foreach (var er in rsNewRole.Errors)
                    {
                        StatusMessage += er.Description;
                    }
                }
            }

            return Page();
        }
    }
}
