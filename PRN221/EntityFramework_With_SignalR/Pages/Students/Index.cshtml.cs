using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityFramework_With_SignalR.Models;

namespace EntityFramework_With_SignalR.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly EntityFramework_With_SignalR.Models.PRN211_1Context _context;

        public IndexModel(EntityFramework_With_SignalR.Models.PRN211_1Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Depart).ToListAsync();
            }
        }

        public IActionResult OnGetStudents()
        {
            var students = _context.Students.Include(s => s.Depart).ToList();
            return new JsonResult(students);
        }
    }
}
