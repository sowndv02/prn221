using LoadDB_ADONet.Models;

namespace LoadDB_ADONet.Repository
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(string id);

    }
}
