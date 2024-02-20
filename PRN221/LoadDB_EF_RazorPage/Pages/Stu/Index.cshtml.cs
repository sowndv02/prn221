using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LoadDB_EF_RazorPage.Models;

namespace LoadDB_EF_RazorPage.Pages.Stu
{
    public class IndexModel : PageModel
    {
        private readonly LoadDB_EF_RazorPage.Models.PRN211_1Context _context;

        public List<Department> Departments { get; set; }
        public List<string> list { get; set; } = default!;

        public IndexModel(LoadDB_EF_RazorPage.Models.PRN211_1Context context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            list = new List<string>();
            Departments = _context.Departments.ToList();
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Depart).ToListAsync();
            }
        }

        public IActionResult OnPost(IFormCollection f)
        {
            list = new List<string>();
            if (f.ContainsKey("all"))
            {
                list.Add("all");
                Student = _context.Students.Include(s => s.Depart).ToList();
            }
            else
            {
                foreach(var d in _context.Departments.ToList())
                {
                    if(f.ContainsKey("chk" + d.Id)) list.Add(d.Id);
                }
                Student = _context.Students.Include(s =>s.Depart).Where(x => list.Contains(x.DepartId)).ToList();
            }
            Departments = _context.Departments.ToList();
            return Page();
        }
    }
}
