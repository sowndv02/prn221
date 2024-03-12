using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.IssueSettings
{
    public class DetailsModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DetailsModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IssueSetting IssueSetting { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IssueSettings == null)
            {
                return NotFound();
            }

            var issuesetting = await _context.IssueSettings.FirstOrDefaultAsync(m => m.SettingId == id);
            if (issuesetting == null)
            {
                return NotFound();
            }
            else
            {
                IssueSetting = issuesetting;
            }
            return Page();
        }
    }
}
