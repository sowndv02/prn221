using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;
using SEP_Management.Utils;
using SEP_Management.Validators;
using System.ComponentModel.DataAnnotations;

namespace SEP_Management.Areas.ClassManager.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;
        private readonly SEP_ManagementContext _context;
        private readonly ExcelHandler _excelHandler;
        private readonly int PROJECT_MENTOR = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.PROJECT_MENTOR).ToArray().First();
        public IndexModel(SEP_ManagementContext context, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
            _context = context;
            _excelHandler = new ExcelHandler();
        }
        public Project Project { get; set; }
        public User User { get; set; }
        public IList<Project> Projects { get; set; }
        [BindProperty]
        public Class Class { get; set; }
        [BindProperty]
        public ClassStudent ClassStudent { get; set; }
        public IList<ClassStudent> WaitingList { get; set; }
        public SelectList ClassList { get; set; }
        public SelectList MentorList { get; set; }
        [DataType(DataType.Upload)]
        [CheckFileExtensions(Extensions = "xlxs")]
        public IFormFile FileUpload { get; set; }
        public async Task<IActionResult> OnGetAsync(int? classId)
        {
            if (classId == null || _context.Classes == null)
            {
                return NotFound();
            }
            var classObject = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == classId);
            Class = classObject;


            WaitingList = _context.ClassStudents.Where(x => x.ClassId == classId && x.ProjectId == 0).Include(x => x.Student).ToList();
            ClassList = new SelectList(_context.Classes.ToList(), "ClassId", "ClassCode");
            MentorList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(PROJECT_MENTOR)).ToList(), "Id", "FullName");

            if (WaitingList.Count == 0)
            {
                var activeProject = await _context.Projects.Where(x => x.ClassId == classId).Include(x => x.Class).ToListAsync();
                activeProject.ForEach(x => x.Status = 1);
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
            }

            Projects = await _context.Projects.Where(m => m.ClassId == classId).Include(x => x.Class).ThenInclude(c => c.ClassStudents).ThenInclude(m => m.Student).ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPostAddStudentAsync()
        {
            if (ClassStudent == null)
            {
                return NotFound();
            }
            var student = _context.ClassStudents.Include(x => x.Class).FirstOrDefault(x => x.StudentId.Equals(ClassStudent.StudentId) && x.ClassId == ClassStudent.ClassId);
            student.ProjectId = ClassStudent.ProjectId;
            Class = student.Class;
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
            return Redirect($"/ClassManager/Projects?classId={Class.ClassId}");
        }


        public async Task<IActionResult> OnGetExportAsync(int? id)
        {
            if (id == null || _context.Classes == null)
            {
                return NotFound();
            }
            var listProject = await _context.Projects.Where(x => x.ClassId == id).Include(x => x.Class).ToListAsync();
            //var filePath = Path.Combine(_environment.ContentRootPath, "Excel", _context.Classes.FirstOrDefault(x => x.ClassId == id).ClassCode + ".xlsx");
            var classCode = _context.Classes.FirstOrDefault(x => x.ClassId == id).ClassCode;
            string filePath = Path.Combine(Path.GetTempPath(), classCode + ".xlsx");
            _excelHandler.ExportProjectToExcel(listProject, filePath);
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", classCode + ".xlsx");
        }

        public IActionResult OnGetGetTemplate()
        {
            string filePath = Path.Combine(Path.GetTempPath(), "Template.xlsx");
            _excelHandler.ExportTemplateProject(filePath);
            return PhysicalFile(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Template.xlsx");
        }

        public async Task<IActionResult> OnGetFreezeAsync(int? classId)
        {
            if (classId == null || _context.Classes == null)
            {
                return NotFound();
            }
            var classObject = await _context.Classes.FirstOrDefaultAsync(m => m.ClassId == classId);
            Class = classObject;


            WaitingList = _context.ClassStudents.Where(x => x.ClassId == classId && x.ProjectId == 0).Include(x => x.Student).ToList();
            ClassList = new SelectList(_context.Classes.ToList(), "ClassId", "ClassCode");
            MentorList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(PROJECT_MENTOR)).ToList(), "Id", "FullName");

            if (WaitingList.Count == 0)
            {
                var activeProject = await _context.Projects.Where(x => x.ClassId == classId).Include(x => x.Class).ToListAsync();
                activeProject.ForEach(x => x.Status = 1);
            }

            Projects = await _context.Projects.Where(m => m.ClassId == classId).Include(x => x.Class).ThenInclude(c => c.ClassStudents).ThenInclude(m => m.Student).ToListAsync();

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


        public IActionResult OnPostImport()
        {
            if (FileUpload != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "Excel", string.Concat(DateTime.Now, FileUpload.FileName));
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    FileUpload.CopyTo(fileStream);
                    _excelHandler.ImportProjectFromExcel(file, Class.ClassId);
                }
            }
            return Redirect($"/ClassManager/Projects?classId={Class.ClassId}&handler=Freeze");
        }
        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }


    }
}
