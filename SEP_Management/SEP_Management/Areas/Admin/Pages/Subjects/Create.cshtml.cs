using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Enums;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly RoleManager<Role> _roleManager;
        private readonly int CLASS_MANAGER = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.CLASS_MANAGER).ToArray().First();

        public CreateModel(SEP_Management.Models.SEP_ManagementContext context, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }
        public SelectList ManagerList { get; set; }
        public IList<User> Managers { get; set; }
        public SelectList ActiveList { get; set; }
        public IList<ActiveEnum> Actives { get; set; }
        public IActionResult OnGet()
        {
            string managerRoleId = _roleManager.Roles.SingleOrDefault(x => x.DisplayOrder == CLASS_MANAGER).Id;
            ManagerList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(managerRoleId)), "Id", "FullName");
            Actives = ActiveEnum.GetListActive().Where(x => x.ActiveKey != -1).ToList();
            ActiveList = new SelectList(Actives, "ActiveKey", "DisplayActiveName");
            return Page();
        }

        [BindProperty]
        public Subject Subject { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Subjects == null || Subject == null)
            {
                return Page();
            }
            var checkSubjectCode = _context.Subjects.FirstOrDefault(x => x.SubjectCode.Equals(Subject.SubjectCode));
            bool checkGrade = byte.TryParse(Subject.PassGrade.ToString(), out byte grade);
            if (checkSubjectCode != null || !checkGrade || (grade > 10 && grade < 0))
            {
                return Page();
            }
            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
