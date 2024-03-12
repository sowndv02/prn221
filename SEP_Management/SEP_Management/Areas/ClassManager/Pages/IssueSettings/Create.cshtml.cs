using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.IssueSettings
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["SubjectId"] = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return Page();
        }

        [BindProperty]
        public IssueSetting IssueSetting { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.IssueSettings == null || IssueSetting == null)
            {
                return Page();
            }

            _context.IssueSettings.Add(IssueSetting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
