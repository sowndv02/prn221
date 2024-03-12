using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly int PROJECT_MENTOR = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.PROJECT_MENTOR).ToArray().First();
        public CreateModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClassLists"] = new SelectList(_context.Classes, "ClassId", "ClassCode");
            var projectMentorRoleId = _context.Roles.FirstOrDefault(x => x.DisplayOrder == PROJECT_MENTOR).Id;
            ViewData["MentorList"] = new SelectList(_context.Users.Where(x => x.RoleId.Equals(projectMentorRoleId)).ToList(), "Id", "FullName");
            ViewData["ActiveList"] = new SelectList(ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList(), "ActiveKey", "DisplayActiveName");
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Project.Status = 0;
            if (!ModelState.IsValid || _context.Projects == null || Project == null)
            {
                return Page();
            }
            var checkProjectCode = _context.Projects.FirstOrDefault(x => x.ProjectCode.ToUpper().Equals(Project.ProjectCode.ToUpper()));
            if (checkProjectCode != null)
            {
                return Page();
            }
            Project.ProjectCode = Project.ProjectCode.ToUpper();
            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
