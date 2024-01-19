using LoadDB_EF_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_EF_RazorPage.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly PRN211_1Context _context;
        public IndexModel(PRN211_1Context context)
        {
            _context = context;
        }
        public List<Student> students { get; set; }
        public void OnGet()
        {
            students = _context.Students.Include(x => x.Depart).ToList();
        }
    }
}
