using LoadDB_ADONet.DAL;
using LoadDB_ADONet.Models;
using LoadDB_ADONet.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDB_ADONet.Pages.Students
{
    public class IndexModel : PageModel
    {
        
        public List<Student> students { get; set; }
        public void OnGet()
        {
            students = StudentDAO.GetAllStudents();
        }

        public void OnPost(string? id)
        {
            if(!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int sId))
            {
                Student student = StudentDAO.GetStudentById(sId);
                if(student != null)
                {
                    StudentDAO.DeleteStudent(sId);
                }
            }
            students = StudentDAO.GetAllStudents();
        }
    }
}
