using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Helpers;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly RoleManager<Role> _roleManager;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context, RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
            _context = context;
        }
        private int USER_PER_PAGE = 10;
        public PaginatedList<Subject> Subject { get; set; } = default!;
        public SelectList ManagerList { get; set; }
        public string CurrentFilter { get; set; }
        public int StatusFilter { get; set; } = int.MinValue;
        public string ManagerFilter { get; set; } = string.Empty;
        public SelectList ActiveList { get; set; }
        public IList<ActiveEnum> Actives { get; set; }
        public IList<User> Managers { get; set; }
        private readonly int CLASS_MANAGER = (int)((UserRole[])Enum.GetValues(typeof(UserRole))).Where(role => role == UserRole.CLASS_MANAGER).ToArray().First();

        public async Task OnGetAsync(string? managerId, int? pageIndex, int? statusFilter, string searchString)
        {
            string managerRoleId = _roleManager.Roles.SingleOrDefault(x => x.DisplayOrder == CLASS_MANAGER).Id;
            ManagerList = new SelectList(_context.Users.Where(x => x.RoleId.Equals(managerRoleId)), "Id", "FullName", ManagerFilter);

            Actives = ActiveEnum.GetListActive();
            ActiveList = new SelectList(Actives, "ActiveKey", "DisplayActiveName", StatusFilter);
            if (_context.Subjects != null)
            {
                if (statusFilter != null) StatusFilter = (int)statusFilter;
                CurrentFilter = searchString;
                if (searchString != null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = CurrentFilter;
                }
                List<Subject> subjects = await _context.Subjects.Include(x => x.Manager).ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    subjects = subjects.Where(s => s.SubjectCode.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
                if (statusFilter != null && statusFilter != int.MinValue && statusFilter != -1)
                {
                    subjects = subjects.Where(s => s.IsActive == statusFilter).ToList();
                }
                if (managerId != null && !string.IsNullOrEmpty(managerId) && !managerId.Equals("All"))
                {
                    subjects = subjects.Where(s => s.ManagerId.Equals(managerId)).ToList();
                }

                Subject = await PaginatedList<Subject>.CreateAsync(subjects, pageIndex ?? 1, USER_PER_PAGE);
            }
        }
    }
}