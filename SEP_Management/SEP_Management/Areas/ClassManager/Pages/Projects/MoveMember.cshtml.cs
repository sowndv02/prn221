using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Projects
{
    public class MoveMemberModel : PageModel
    {
        private readonly SEP_ManagementContext _context;
        public User Student { get; set; }
        public Project Project { get; set; }
        public Class Class { get; set; }
        [BindProperty]
        public ClassStudent ClassStudent { get; set; }
        public MoveMemberModel(SEP_ManagementContext context)
        {
            _context = context;
        }
        public IActionResult OnGet(int? classId, string? studentId, int? projectId)
        {
            if (classId == null || studentId == null || projectId == null)
            {
                return NotFound();
            }
            var classStudent = _context.ClassStudents.Include(x => x.Student).Include(x => x.Class).FirstOrDefault(x => x.StudentId.Equals(studentId) && x.ClassId == classId);

            if (classStudent != null)
            {
                Student = classStudent.Student;
                Class = classStudent.Class;
            }
            Project = _context.Projects.FirstOrDefault(x => x.ProjectId == classStudent.ProjectId);
            ViewData["Projects"] = new SelectList(_context.Projects.Where(x => x.ClassId == classId && x.ProjectId != projectId).ToList(), "ProjectId", "ProjectCode");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var student = _context.ClassStudents.FirstOrDefault(x => x.StudentId == ClassStudent.StudentId && x.ClassId == ClassStudent.ClassId);
            student.IsLeader = 0;
            student.ProjectId = ClassStudent.ProjectId;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassStudentExists(ClassStudent.ClassStId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Redirect($"/ClassManager/Projects?classId={ClassStudent.ClassId}");
        }
        private bool ClassStudentExists(int id)
        {
            return (_context.ClassStudents?.Any(e => e.ClassStId == id)).GetValueOrDefault();
        }
    }
}
