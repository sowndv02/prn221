using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }
        private readonly int PROJECT_MENTOR = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.PROJECT_MENTOR).ToArray().First();
        [BindProperty]
        public Project Project { get; set; } = default!;
        [BindProperty]
        public Class Class { get; set; }
        [BindProperty]
        public ClassStudent ClassStudent { get; set; }
        public User User { get; set; }
        public IList<Project> Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? projectId)
        {
            if (projectId == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == projectId);
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            var project = _context.Projects.FirstOrDefault(x => x.ProjectId == Project.ProjectId && x.ClassId == Project.ClassId);
            project.ClassId = Project.ClassId;
            project.GroupName = Project.GroupName;
            project.ProjectEnName = Project.ProjectEnName;
            project.ProjectVieName = Project.ProjectVieName;
            project.ProjectCode = Project.ProjectCode;
            project.MentorId = Project.MentorId;
            project.CoMentorId = Project.CoMentorId;
            project.ProjectDescription = Project.ProjectDescription;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.ProjectId))
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

        public IActionResult OnGetMoveMember(int? classId, int? projectId, string? studentId)
        {
            if (classId == null || projectId == null || studentId == null)
            {
                return NotFound();
            }
            var student = _context.ClassStudents.FirstOrDefault(x => x.ProjectId == projectId && x.ClassId == classId && x.StudentId.Equals(studentId));

            if (student != null)
            {
                student.IsLeader = 0;
                student.ProjectId = (int)projectId;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Redirect($"/ClassManager/Projects?classId={classId}");
        }

        public IActionResult OnGetSetLeader(int? classId, int? projectId, string? studentId)
        {
            if (classId == null || projectId == null || studentId == null)
            {
                return NotFound();
            }
            var resetLeader = _context.ClassStudents.Where(x => x.ProjectId == projectId && x.ClassId == classId).ToList();
            resetLeader.ForEach(x => x.IsLeader = 0);
            var student = _context.ClassStudents.FirstOrDefault(x => x.ProjectId == projectId && x.ClassId == classId && x.StudentId.Equals(studentId));

            if (student != null)
            {
                student.IsLeader = 1;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }

            return Redirect($"/ClassManager/Projects?classId={classId}");
        }
        public async Task<IActionResult> OnGetChangeStatusAsync(string status, string id, int classId)
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
            return Redirect($"/ClassManager/Projects?classId={classId}");
        }
        public async Task<IActionResult> OnGetRemoveMemberAsync(string studentId, int? classId, int? projectId)
        {
            if (studentId == null || _context.Users == null || classId == null || projectId == null)
            {
                return NotFound();
            }

            var user = await _context.ClassStudents.FirstOrDefaultAsync(m => m.StudentId == studentId && m.ClassId == classId && m.ProjectId == projectId);
            if (user == null)
            {
                return NotFound();
            }
            user.ProjectId = 0;
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
            return Redirect($"/ClassManager/Projects?classId={classId}");
        }

        public async Task<IActionResult> OnGetRemoveProjectAsync(int? projectId)
        {
            if (_context.Projects == null || projectId == null)
            {
                return NotFound();
            }
            var project = await _context.Projects.FirstOrDefaultAsync(m => m.ProjectId == projectId);
            if (project == null)
            {
                return NotFound();
            }
            var classId = project.ClassId;
            if (project.Status == 1)
            {
                return Redirect($"/ClassManager/Projects?classId={classId}");
            }
            else
            {
                _context.Projects.Remove(project);
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
            return Redirect($"/ClassManager/Projects?classId={classId}");
        }
        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }
    }
}
