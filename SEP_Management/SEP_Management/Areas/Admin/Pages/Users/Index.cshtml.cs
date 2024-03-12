using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Helpers;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Users
{
    //[Authorize(Roles = "Admin, Class Manager, Subject Manager")] // Role-based
    public class IndexModel : PageModel
    {
        private int USER_PER_PAGE = 10;
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        private readonly RoleManager<Role> _roleManager;
        private readonly IAuthorizationService _authorizationService;
        public IndexModel(SEP_Management.Models.SEP_ManagementContext context, RoleManager<Role> roleManager, IAuthorizationService authorizationService)
        {
            _context = context;
            _roleManager = roleManager;
            _authorizationService = authorizationService;
        }
        public string NameSort { get; set; }
        public string EmailSort { get; set; }
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StatusFilter { get; set; } = int.MinValue;
        [BindProperty(SupportsGet = true)]
        public string RoleFilter { get; set; } = string.Empty;
        public string CurrentSort { get; set; }
        public PaginatedList<User> User { get; set; } = default!;
        public SelectList RoleList { get; set; }
        public IList<Role> Roles { get; set; }
        public SelectList ActiveList { get; set; }
        public IList<ActiveEnum> Actives { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex, int? statusFilter, string? roleFilter)
        {
            Roles = await _roleManager.Roles.OrderBy(x => x.DisplayOrder).ToListAsync();
            Actives = ActiveEnum.GetListActive();
            RoleList = new SelectList(Roles, "Id", "Name", RoleFilter);
            ActiveList = new SelectList(Actives, "ActiveKey", "DisplayActiveName", StatusFilter);
            if (_context.Users != null)
            {
                NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                if (statusFilter != null) StatusFilter = (int)statusFilter;
                if (roleFilter != null) RoleFilter = roleFilter;
                EmailSort = sortOrder == "Email" ? "email_desc" : "Email";
                CurrentFilter = searchString;
                if (searchString != null)
                {
                    pageIndex = 1;
                }
                else
                {
                    searchString = CurrentFilter;
                }
                List<User> users = await _context.Users.Include(x => x.Role).ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    users = users.Where(s => s.Email.ToUpper().Contains(searchString.ToUpper()) || s.FullName.ToUpper().Contains(searchString.ToUpper())).ToList();
                }
                if (statusFilter != null && statusFilter != int.MinValue && statusFilter != -1)
                {
                    users = users.Where(s => s.IsActive == statusFilter).ToList();
                }
                if (roleFilter != null && !string.IsNullOrEmpty(roleFilter) && !roleFilter.Equals("All"))
                {
                    users = users.Where(s => s.Role.Id.Equals(roleFilter)).ToList();
                }

                switch (sortOrder)
                {
                    case "name_desc":
                        users = users.OrderByDescending(s => s.FullName.Split(' ').LastOrDefault()).ToList();
                        break;
                    case "Email":
                        users = users.OrderBy(s => s.Email).ToList();
                        break;
                    case "email_desc":
                        users = users.OrderByDescending(s => s.Email).ToList().ToList();
                        break;
                    default:
                        users = users.OrderBy(s => s.FullName.Split(' ').LastOrDefault()).ToList();
                        break;
                }
                User = await PaginatedList<User>.CreateAsync(users, pageIndex ?? 1, USER_PER_PAGE);
            }
        }
    }
}

