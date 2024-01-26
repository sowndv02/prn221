using LoadDB_ADONet.DAL;
using LoadDB_ADONet.Models;
using LoadDB_ADONet.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography;

namespace LoadDB_ADONet.Pages.Students
{
    public class EditModel : PageModel
    {
        
        [BindProperty]
        public Student std { get; set; }
        public List<Department> departments { get; private set; }
        public void OnGet(string? id)
        {
            if(!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int sId))
                std = StudentDAO.GetStudentById(sId);
            ViewData["departments"] = new SelectList(DepartmentDAO.GetAllDepartments(), "Id", "Name");
            ViewData["genders"] = new SelectList(new[]
            {
                new { Value = true, Text = "Male" },
                new { Value = false, Text = "Female" }
            }
            , "Value", "Text");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var st = StudentDAO.GetStudentById(std.Id);
                if (st != null) 
                {
                    st.Name = std.Name;
                    st.Gender = std.Gender;
                    st.Dob = std.Dob;
                    st.DepartId = std.DepartId;
                    st.Gpa = std.Gpa;   
                    StudentDAO.UpdateStudent(st);
                }
            }
            return Redirect("/Students/Index");
        }
    }
}
