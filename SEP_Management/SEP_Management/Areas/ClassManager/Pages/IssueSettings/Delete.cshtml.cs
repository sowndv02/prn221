using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.IssueSettings
{
    public class DeleteModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public DeleteModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IssueSettings == null)
            {
                return NotFound();
            }
            var issuesetting = await _context.IssueSettings.FindAsync(id);

            if (issuesetting != null)
            {
                IssueSetting = issuesetting;
                _context.IssueSettings.Remove(IssueSetting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
