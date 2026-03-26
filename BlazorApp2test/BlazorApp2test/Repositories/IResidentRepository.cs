using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IResidentRepository
    {
        Task<List<Resident>> GetAllResidentsAsync();
        Task<List<Resident>> GetResidentByDepartmentIdAsync(int departmentId);
        Task<int> SaveNewResidentAsync(Resident resident);
        Task DeleteResidentAsync(int residentId);
        Task UpdateResidentAsync(Resident resident);
    }
}