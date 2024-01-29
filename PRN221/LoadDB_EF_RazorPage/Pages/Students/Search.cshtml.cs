using LoadDB_EF_RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LoadDB_EF_RazorPage.Pages.Students
{
    public class SearchModel : PageModel
    {
        private readonly PRN211_1Context _context;
        public List<Student> students { get; set ; } = new List<Student>(); 
        public SearchModel(PRN211_1Context context) 
        {
            _context = context;
        }
        public void OnPost() { }

        public IActionResult OnGet(string[]? departmentsSearch)
        {
            string searchType = Request.Query["searchType"];
            if (searchType == "type1")
            {
                if (bool.TryParse(Request.Query["gender"], out bool gender))
                {
                    students = _context.Students.Where(x => x.Gender == gender).Include(x => x.Depart).ToList();
                }
            }
            else if (searchType == "type2")
            {
                if (Request.Query["male"].Count > 0)
                {
                    students = _context.Students.Where(x => x.Gender == true).Include(x => x.Depart).ToList();
                }
                if (Request.Query["female"].Count > 0)
                {
                    students = _context.Students.Where(x => x.Gender == false).Include(x => x.Depart).ToList();
                }
                if (Request.Query["male"].Count > 0 && Request.Query["female"].Count > 0)
                {
                    students = _context.Students.Include(x => x.Depart).ToList();
                }
            }
            else if (searchType == "type3")
            {
                string data = Request.Query["gender"];
                if (!string.IsNullOrEmpty(data))
                {
                    if (bool.TryParse(data, out bool gender))
                    {
                        students = _context.Students.Where(x => x.Gender == gender).Include(x => x.Depart).ToList();
                    }
                }
                else
                {
                    students = _context.Students.Include(x => x.Depart).ToList();
                }

            }
            else if (searchType == "type4")
            {
                string key = Request.Query["department"];
                if (!string.IsNullOrEmpty(key))
                {
                    students = _context.Students.Where(x => x.DepartId == key).Include(x => x.Depart).ToList();
                }
                else
                {
                    students = _context.Students.Include(x => x.Depart).ToList();
                }

            }
            else if(searchType == "type5")
            {
                if (departmentsSearch.Length > 0)
                {
                    students = _context.Students
                    .Where(student => departmentsSearch.Contains(student.DepartId))
                    .Include(x => x.Depart)
                    .ToList();
                }
                else
                {
                    students = _context.Students.Include(x => x.Depart).ToList();
                }

            }
            else if(searchType == "type6")
            {
                string key = Request.Query["department"];
                if (!string.IsNullOrEmpty(key))
                {
                    students = _context.Students.Where(x => x.DepartId == key).Include(x => x.Depart).ToList();
                }
                else
                {
                    students = _context.Students.Include(x => x.Depart).ToList();
                }
            }
            else if(searchType == "type7")
            {
                string key = Request.Query["department"];
                
                
                if (!string.IsNullOrEmpty(key))
                {
                    if (Request.Query["male"].Count > 0)
                    {
                        students = _context.Students.Where(x => x.Gender == true && x.DepartId == key).Include(x => x.Depart).ToList();
                    }
                    if (Request.Query["female"].Count > 0)
                    {
                        students = _context.Students.Where(x => x.Gender == false && x.DepartId == key).Include(x => x.Depart).ToList();
                    }
                    if (Request.Query["male"].Count > 0 && Request.Query["female"].Count > 0)
                    {
                        students = _context.Students.Include(x => x.Depart).Where(x => x.DepartId == key).ToList();
                    }
                }
                else
                {
                    if (Request.Query["male"].Count > 0)
                    {
                        students = _context.Students.Where(x => x.Gender == true).Include(x => x.Depart).ToList();
                    }
                    if (Request.Query["female"].Count > 0)
                    {
                        students = _context.Students.Where(x => x.Gender == false).Include(x => x.Depart).ToList();
                    }
                    if (Request.Query["male"].Count > 0 && Request.Query["female"].Count > 0)
                    {
                        students = _context.Students.Include(x => x.Depart).ToList();
                    }
                }
            }
            return Page();
        }
    }
}
