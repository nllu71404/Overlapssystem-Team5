using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<int> SaveNewDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int departmentId);
        Task UpdateDepartmentAsync(Department department);
        // Tilføj metoder til at hente en afdeling efter ID og navn
        Task<Department> GetDepartmentByIdAsync(int departmentId);
        Task<Department> GetDepartmentByNameAsync(string departmentName);
    }
}
