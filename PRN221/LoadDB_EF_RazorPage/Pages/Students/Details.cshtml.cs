using LoadDB_EF_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_EF_RazorPage.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly PRN211_1Context _context;
        public Student std { get; private set; }
        public DetailsModel(PRN211_1Context context) 
        {
            _context = context;
        }
        public void OnGet(string? id)
        {
            if(!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int studentId))
                std = _context.Students.Include(x => x.Depart).FirstOrDefault(x => x.Id == studentId);
        }
    }
}
