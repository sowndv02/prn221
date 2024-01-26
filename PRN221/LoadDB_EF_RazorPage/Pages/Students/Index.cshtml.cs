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

        public void OnPost(string? id)
        {
            if(!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int sId))
            {
                Student student = _context.Students.SingleOrDefault(x => x.Id == sId);
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            students = _context.Students.Include(x => x.Depart).ToList();
        }
    }
}
