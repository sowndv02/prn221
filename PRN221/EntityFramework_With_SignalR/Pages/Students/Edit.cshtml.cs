using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework_With_SignalR.Models;
using EntityFramework_With_SignalR.SignalRConfig;
using Microsoft.AspNetCore.SignalR;

namespace EntityFramework_With_SignalR.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly EntityFramework_With_SignalR.Models.PRN211_1Context _context;
        private readonly SignalrServer _signalRHub;
        public EditModel(EntityFramework_With_SignalR.Models.PRN211_1Context context, SignalrServer signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;   
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student =  await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
           ViewData["DepartId"] = new SelectList(_context.Departments, "Id", "Id");
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

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Send client
                await _signalRHub.Clients.All.SendAsync("LoadStudents");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.Id))
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

        private bool StudentExists(int id)
        {
          return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
