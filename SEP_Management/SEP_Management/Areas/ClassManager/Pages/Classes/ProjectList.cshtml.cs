using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;
using SEP_Management.Utils;

namespace SEP_Management.Areas.ClassManager.Pages.Classes
{
    public class ProjectListModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly SEP_ManagementContext _context;
        private readonly int PROJECT_MENTOR = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.PROJECT_MENTOR).ToArray().First();
        public ProjectListModel(SEP_ManagementContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
            _context = context;
        }
        public IList<Project> Projects { get; set; }
        public Class Class { get; set; }
        public IList<Project> ProjectsForAdd { get; set; }
        public IList<ClassStudent> WaitingList { get; set; }
        public SelectList ClassList { get; set; }
        public SelectList MentorList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }

            var projects = await _context.Projects.Where(m => m.ClassId == id).ToListAsync();
            var classObject = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == id);
            if (projects == null || classObject == null)
            {
                return NotFound();
            }
            else
            {
                Class = classObject;
                Projects = projects;
            }
            return Page();
        }

        public async Task<IActionResult> OnGetExportAsync(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var listProject = await _context.Projects.Where(x => x.ClassId == id).Include(x => x.Class).ToListAsync();
            ExcelHandler excelHandler = new ExcelHandler();
            //var filePath = Path.Combine(_environment.ContentRootPath, "Excel", _context.Classes.FirstOrDefault(x => x.ClassId == id).ClassCode + ".xlsx");
            string filePath = Path.Combine(Path.GetTempPath(), _context.Classes.FirstOrDefault(x => x.ClassId == id).ClassCode + ".xlsx");
            excelHandler.ExportProjectToExcel(listProject, filePath);
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", _context.Classes.FirstOrDefault(x => x.ClassId == id).ClassCode + ".xlsx");
        }
        public async Task<IActionResult> OnGetFreezeAsync(int? classId)
        {
            if (classId == null || _context.Classes == null)
            {
                return NotFound();
            }
            var classObject = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == classId);
            Class = classObject;
            var checWaitingList = _context.ClassStudents.Where(x => x.ClassId == classId && x.ProjectId == 0).ToList();
            ProjectsForAdd = await _context.Projects.Where(m => m.ClassId == classId).Include(x => x.Class).ThenInclude(c => c.ClassStudents).ThenInclude(m => m.Student).ToListAsync();
            var projectsForRemove = new List<Project>(ProjectsForAdd);
            WaitingList = await _context.ClassStudents.Where(x => x.ClassId == classId && x.ProjectId == 0).Include(x => x.Student).ToListAsync();
            ClassList = new SelectList(_context.Classes.ToList(), "ClassId", "ClassCode");
            MentorList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(PROJECT_MENTOR)).ToList(), "Id", "FullName");
            if (checWaitingList == null || checWaitingList.Count == 0)
            {
                string roleMentorId = _context.Roles.FirstOrDefault(x => x.DisplayOrder == PROJECT_MENTOR).Id.ToString();
                var activeProject = await _context.Projects.Where(x => x.ClassId == classId).Include(x => x.Class).ToListAsync();
                activeProject.ForEach(x => x.Status = 1);
                var mentorList = await _context.Users.Where(x => x.RoleId.Equals(roleMentorId)).ToListAsync();
                var waitingList = await _context.ClassStudents.Where(x => x.ClassId == classId && x.ProjectId == 0).ToListAsync();
                string freezeResult = "Success";
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists((int)classId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Page();
        }
        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
