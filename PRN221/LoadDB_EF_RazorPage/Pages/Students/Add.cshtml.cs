using LoadDB_EF_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoadDB_EF_RazorPage.Pages.Students
{
    public class AddModel : PageModel
    {
        private readonly PRN211_1Context _context;
        public AddModel(PRN211_1Context context)
        {
            _context = context;
        }
        [BindProperty]
        public Student std {  get; set; }
        public List<Department> dept { get; private set; }
        public void OnGet()
        {
            //dept = _context.Departments.ToList();
            ViewData["departments"] = new SelectList(_context.Departments.ToList(), "Id", "Name");
        }
                                
        public IActionResult OnPost()
        {
            //int id = int.Parse(f["id"]); // IFormCollection f
            //int id = int.Parse(Request.Form["id"]);
            // OnPost(int id)
            if(ModelState.IsValid)
            {
                var x = _context.Students.Find(std.Id);
                if (x != null) { return Redirect("/Students/Index"); }
                _context.Students.Add(std);
                _context.SaveChanges();
            }
            return Redirect("/Students/Index");
        }
    }
}
