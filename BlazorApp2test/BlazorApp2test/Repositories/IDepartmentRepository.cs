using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IDepartmentRepository
    {
        List<Department> GetAllDepartment();
        int SaveNewDepartment(Department department);
        void DeleteDepartment(int departmentId);
        void UpdateDepartment(Department department);
    }
}
