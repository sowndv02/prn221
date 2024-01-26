using LoadDB_ADONet.DAL;
using LoadDB_ADONet.Models;
using LoadDB_ADONet.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LoadDB_ADONet.Pages.Students
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Student std {  get; set; }
        public List<Department> departments { get; private set; }
        public void OnGet()
        {
            departments = DepartmentDAO.GetAllDepartments();
        }
                                
        public IActionResult OnPost(IFormCollection form)
        {
            //int id = int.Parse(Request.Form["id"]);
            // OnPost(int id)
            if (!string.IsNullOrEmpty(form["id"]) && int.TryParse(form["id"], out int sid))
             {
                Student x = StudentDAO.GetStudentById(sid);
                if (x != null) { return Redirect("/Students/Index"); }
                std.Id = sid;
                std.Name = form["name"];
                std.Gender = form["gender"] == "1" ? true : false;
                std.Dob = DateTime.Parse(form["dob"]);
                std.Gpa = decimal.Parse(form["gpa"]);
                std.DepartId = form["departId"];
                StudentDAO.AddStudent(std);
             }
                
            return Redirect("/Students/Index");
        }
    }
}
