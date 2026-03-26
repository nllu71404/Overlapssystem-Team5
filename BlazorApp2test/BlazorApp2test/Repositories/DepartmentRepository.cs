using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task DeleteDepartmentAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentByNameAsync(string departmentName)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveNewDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDepartmentAsync(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
