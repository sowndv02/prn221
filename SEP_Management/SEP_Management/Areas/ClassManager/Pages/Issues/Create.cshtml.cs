using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Issues
{
    public class CreateModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public CreateModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MilestoneId"] = new SelectList(_context.Milestones, "MilestoneId", "MilestoneId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["TypeId"] = new SelectList(_context.IssueSettings, "SettingId", "SettingId");
            return Page();
        }

        [BindProperty]
        public Issue Issue { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Issues == null || Issue == null)
            {
                return Page();
            }

            _context.Issues.Add(Issue);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
