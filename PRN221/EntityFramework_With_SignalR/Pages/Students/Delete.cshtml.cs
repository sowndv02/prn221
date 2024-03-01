using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework_With_SignalR.Models;
using Microsoft.AspNetCore.SignalR;
using EntityFramework_With_SignalR.SignalRConfig;

namespace EntityFramework_With_SignalR.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly EntityFramework_With_SignalR.Models.PRN211_1Context _context;
        private readonly IHubContext<SignalrServer> _hubContext;
        public DeleteModel(EntityFramework_With_SignalR.Models.PRN211_1Context context, IHubContext<SignalrServer> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
      public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            else 
            {
                Student = student;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                Student = student;
                _context.Students.Remove(Student);
                await _context.SaveChangesAsync();
                await _hubContext.Clients.All.SendAsync("LoadAll");
            }

            return RedirectToPage("./Index");
        }
    }
}
