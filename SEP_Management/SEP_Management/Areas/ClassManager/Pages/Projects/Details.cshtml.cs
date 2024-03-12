using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly int PROJECT_MENTOR = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.PROJECT_MENTOR).ToArray().First();
        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? projectId, int? classId)
        {
            if (projectId == null || classId == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == projectId && m.ClassId == classId);
            if (project == null)
            {
                return NotFound();
            }
            Project = project;
            ViewData["Classes"] = new SelectList(_context.Classes, "ClassId", "ClassCode");
            var roleMentorId = _context.Roles.FirstOrDefault(x => x.DisplayOrder == PROJECT_MENTOR);
            ViewData["Mentors"] = new SelectList(_context.Users.Where(x => x.RoleId.Equals(roleMentorId)).ToList(), "Id", "FullName");
            return Page();
        }
    }
}
