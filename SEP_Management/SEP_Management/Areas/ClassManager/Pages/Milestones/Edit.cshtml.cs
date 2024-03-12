using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEP_Management.Models;

namespace SEP_Management.Areas.ClassManager.Pages.Milestones
{
    public class EditModel : PageModel
    {
        private readonly SEP_Management.Models.SEP_ManagementContext _context;

        public EditModel(SEP_Management.Models.SEP_ManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Milestone Milestone { get; set; } = default!;

        [BindProperty]
        public Project Project { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Milestones == null)
            {
                return NotFound();
            }

            var milestone = await _context.Milestones.FirstOrDefaultAsync(m => m.MilestoneId == id);
            if (milestone == null)
            {
                return NotFound();
            }
            Milestone = milestone;
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Milestone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilestoneExists(Milestone.MilestoneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostSyncGitLabAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MilestoneExists(Milestone.MilestoneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        private bool MilestoneExists(int id)
        {
            return (_context.Milestones?.Any(e => e.MilestoneId == id)).GetValueOrDefault();
        }
    }
}
