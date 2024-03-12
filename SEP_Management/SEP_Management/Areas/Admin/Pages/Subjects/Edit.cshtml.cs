using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.SubjectManager.Pages.Subjectss
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly RoleManager<Role> _roleManager;
        public SelectList ManagerList { get; set; }
        public IList<User> Managers { get; set; }
        public SelectList ActiveList { get; set; }
        public IList<ActiveEnum> Actives { get; set; }
        public EditModel(SEP_Management.Models.SEP_ManagementContext context, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }
        private readonly int CLASS_MANAGER = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.CLASS_MANAGER).ToArray().First();

        [BindProperty]
        public Subject Subject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string managerRoleId = _roleManager.Roles.SingleOrDefault(x => x.DisplayOrder == CLASS_MANAGER).Id;
            ManagerList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(managerRoleId)), "Id", "FullName");
            Actives = ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList();
            ActiveList = new SelectList(Actives, "ActiveKey", "DisplayActiveName");
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            Subject = subject;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var checkSubjectCode = _context.Subjects.FirstOrDefault(x => x.SubjectCode.Equals(Subject.SubjectCode));
            if (checkSubjectCode != null && !checkSubjectCode.SubjectId.Equals(Subject.SubjectId))
            {
                return Page();
            }
            var subject = _context.Subjects.FirstOrDefault(x => x.SubjectId.Equals(Subject.SubjectId));
            subject.ManagerId = Subject.ManagerId;
            subject.SubjectName = Subject.SubjectName;
            subject.SubjectCode = Subject.SubjectCode;
            subject.PassGrade = Subject.PassGrade;
            subject.TimeAllocation = Subject.TimeAllocation;
            subject.IsActive = Subject.IsActive;
            subject.Description = Subject.Description;
            subject.UpdatedAt = DateTime.Now;
            //_context.Attach(Subject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(Subject.SubjectId))
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

        public async Task<IActionResult> OnGetChangeStatusAsync(string status, int id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FirstOrDefaultAsync(m => m.SubjectId == id);
            if (subject == null)
            {
                return NotFound();
            }
            Subject = subject;
            if (status.ToUpper().Equals("InActive".ToUpper()))
            {
                Subject.IsActive = 1;
            }
            else if (status.ToUpper().Equals("Active".ToUpper()))
            {
                Subject.IsActive = 0;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(Subject.SubjectId))
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

        private bool SubjectExists(int id)
        {
            return (_context.Subjects?.Any(e => e.SubjectId == id)).GetValueOrDefault();
        }
    }
}
