using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Enums;
using SEP_Management.Helpers;
using SEP_Management.Models;

namespace SEP_Management.Areas.Admin.Pages.Roles
{
    public class IndexModel : PageModel
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly SEP_ManagementContext _context;

        public IndexModel(RoleManager<Role> roleManager, SEP_ManagementContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        private int USER_PER_PAGE = 10;
        public PaginatedList<Role> Role { get; set; } = default!;
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public int StatusFilter { get; set; } = int.MinValue;
        [BindProperty(SupportsGet = true)]
        public int GroupFilter { get; set; } = int.MinValue;
        public SelectList ActiveList { get; set; }
        public SelectList SettingGroupList { get; set; }
        public IList<ActiveEnum> Actives { get; set; }
        public async Task OnGetAsync(int? pageIndex, int? statusFilter, int? groupFilter)
        {
            Actives = ActiveEnum.GetListActive();
            ActiveList = new SelectList(Actives, "ActiveKey", "DisplayActiveName", StatusFilter);

            var settingGroupValues = Enum.GetValues(typeof(SettingGroup))
                                .Cast<SettingGroup>()
                                .Select(s => new SelectListItem
                                {
                                    Value = ((int)s).ToString(),
                                    Text = Enum.GetName(typeof(SettingGroup), s)
                                });
            SettingGroupList = new SelectList(settingGroupValues, "Value", "Text");

            if (_roleManager.Roles != null)
            {
                if (statusFilter != null) StatusFilter = (int)statusFilter;
                if (groupFilter != null) GroupFilter = (int)groupFilter;
                List<Role> roles = await _context.Roles.ToListAsync();
                if (statusFilter != null && statusFilter != int.MinValue && statusFilter != -1)
                {
                    roles = roles.Where(s => s.IsActive == statusFilter).ToList();
                }
                if (groupFilter != null && groupFilter != int.MinValue && groupFilter != -1)
                {
                    roles = roles.Where(s => s.Group == groupFilter).ToList();
                }
                Role = await PaginatedList<Role>.CreateAsync(roles, pageIndex ?? 1, USER_PER_PAGE);
            }
        }
    }
}
