using LoadDB_ADONet.Models;

namespace LoadDB_ADONet.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetStudentById(int id);    
        int AddNewStudent(Student student);
        int UpdateStudent(Student student);
        int DeleteStudent(int id);  
    }
}
