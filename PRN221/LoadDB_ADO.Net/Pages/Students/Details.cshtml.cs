using LoadDB_ADONet.DAL;
using LoadDB_ADONet.Models;
using LoadDB_ADONet.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoadDB_ADONet.Pages.Students
{
    public class DetailsModel : PageModel
    {
        public Student std { get; private set; }
        public void OnGet(string? id)
        {
            if(!string.IsNullOrWhiteSpace(id) && int.TryParse(id, out int studentId))
                std = StudentDAO.GetStudentById(studentId);
        }
    }
}
