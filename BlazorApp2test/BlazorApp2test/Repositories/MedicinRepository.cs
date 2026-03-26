using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public class MedicinRepository : IMedicinRepository
    {
        public Task DeleteMedicinAsync(int medicinId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Medicin>> GetAllMedicinAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Medicin>> GetMedicinByResidentIdAsync(int residentId)
        {
            throw new NotImplementedException();
        }

        public Task SaveNewMedicinAsync(Medicin medicin)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedicinAsync(Medicin medicin)
        {
            throw new NotImplementedException();
        }
    }
}
