using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IMedicinRepository
    {
        List<Medicin> GetAllMedicin();
        List<Medicin> GetMedicinByResidentId(int residentId);
        int SaveNewMedicin(Medicin medicin);
        void DeleteMedicin(int medicinId);
        void UpdateMedicin(Medicin medicin);
    }
}
