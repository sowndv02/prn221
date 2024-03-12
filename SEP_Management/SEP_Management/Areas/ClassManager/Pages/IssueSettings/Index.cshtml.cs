using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.IssueSettings
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;
        public Project Project { get; set; }

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<IssueSetting> IssueSetting { get; set; } = default!;

        public async Task OnGetAsync(int? projectId)
        {
            if (_context.IssueSettings != null)
            {
                Project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
                IssueSetting = await _context.IssueSettings
                .Include(i => i.Class)
                .Include(i => i.Project)
                .Include(i => i.Subject).Where(x => x.ProjectId == projectId).ToListAsync();
            }
        }
    }
}
