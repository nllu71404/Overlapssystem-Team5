using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IMedicinRepository
    {
        Task<List<Medicin>> GetAllMedicinAsync();
        Task<List<Medicin>> GetMedicinByResidentIdAsync(int residentId);
        Task SaveNewMedicinAsync(Medicin medicin);
        Task DeleteMedicinAsync(int medicinId);
        Task UpdateMedicinAsync(Medicin medicin);
    }
}
