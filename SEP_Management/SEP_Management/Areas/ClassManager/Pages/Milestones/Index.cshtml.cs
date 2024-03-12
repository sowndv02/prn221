using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Milestones
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<Milestone> Milestone { get; set; } = default!;
        public Project Project { get; set; }

        public async Task<IActionResult> OnGetAsync(int? projectId)
        {
            if (projectId == null)
                return NotFound();
            if (_context.Milestones != null)
            {
                Project = await _context.Projects.FirstOrDefaultAsync(x => x.ProjectId == projectId);
                Milestone = await _context.Milestones
                .Include(m => m.Class)
                .Include(m => m.Project).Where(x => x.ProjectId == projectId).ToListAsync();
            }
            return Page();
        }
    }
}
