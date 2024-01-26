using LoadDB_EF_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoadDB_EF_RazorPage.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly PRN211_1Context _context;
        public EditModel(PRN211_1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Student std { get; set; }
        public List<Department> departments { get; private set; }
        public void OnGet(string? id)
        {
            if (!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int sId))
                std = _context.Students.Find(int.Parse(id));
            ViewData["departments"] = new SelectList(_context.Departments.ToList(), "Id", "Name");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var st = _context.Students.Find(std.Id);
                if(st != null) 
                {
                    st.Name = std.Name;
                    st.Gender = std.Gender;
                    st.Dob = std.Dob;
                    st.DepartId = std.DepartId;
                    st.Gpa = std.Gpa;   
                    _context.SaveChanges();
                }
            }
            return Redirect("/Students/Index");
        }
    }
}
