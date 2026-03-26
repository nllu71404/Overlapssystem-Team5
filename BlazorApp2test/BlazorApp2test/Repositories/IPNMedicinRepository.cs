using BlazorApp2test.Models;

namespace BlazorApp2test.Repositories
{
    public interface IPNMedicinRepository
    {
        List<PNMedicin> GetAllPNMedicin();
        List<PNMedicin> GetPNMedicinByResidentId(int residentId);
        int SaveNewPNMedicin(PNMedicin pNMedicin);
        void DeletePNMedicin(int pNMedicinId);
        void UpdatePNMedicin(PNMedicin pNMedicin);
    }
}
