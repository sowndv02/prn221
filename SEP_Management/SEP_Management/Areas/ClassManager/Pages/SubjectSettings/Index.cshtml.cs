using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.SubjectSettings
{
    public class IndexModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public IndexModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IList<SubjectSetting> SubjectSetting { get; set; } = default!;
        public Subject Subject { get; set; }

        public async Task OnGetAsync(int? subjectId)
        {
            if (_context.SubjectSettings != null)
            {
                Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.SubjectId == subjectId);
                SubjectSetting = await _context.SubjectSettings
                .Include(s => s.Subject).Where(x => x.SubjectId == subjectId).ToListAsync();
            }
        }
    }
}
