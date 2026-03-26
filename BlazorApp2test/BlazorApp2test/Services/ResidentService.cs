using BlazorApp2test.Models;
using BlazorApp2test.Repositories;

namespace BlazorApp2test.Services
{
    public class ResidentService
    {
        private readonly IResidentRepository _residentRepository;

        public ResidentService(IResidentRepository residentRepository)
        {
            _residentRepository = residentRepository;
        }

        public List<Resident> Residents { get; private set; } = new();
        public int SelectedDepartmentId { get; set; } = 1;

        public Resident NewResident { get; set; } = new Resident
        {
            Risiko = Risiko.Green
        };

        // Henter alle beboere ved at kalde på funktion i ResidentRepository
        public async Task LoadResidentsAsync()
        {
            Residents = await _residentRepository.GetAllResidentsAsync();
        }

        public async Task LoadResidentsByDepartmentAsync()
        {
            Residents = await _residentRepository.GetResidentByDepartmentIdAsync(SelectedDepartmentId);
        }

        public async Task SaveResidentAsync(Resident resident)
        {
            resident.DepartmentId = SelectedDepartmentId;
            await _residentRepository.UpdateResidentAsync(resident);
            Residents = await _residentRepository.GetResidentByDepartmentIdAsync(SelectedDepartmentId);
        }

        public async Task DeleteResidentAsync(Resident resident)
        {
            if (!resident.ResidentId.HasValue)
                return;

            await _residentRepository.DeleteResidentAsync(resident.ResidentId.Value);
            Residents = await _residentRepository.GetResidentByDepartmentIdAsync(SelectedDepartmentId);
        }

        public async Task CreateResidentAsync()
        {
            NewResident.DepartmentId = SelectedDepartmentId;
            await _residentRepository.SaveNewResidentAsync(NewResident);

            NewResident = new Resident
            {
                Risiko = Risiko.Green,
                DepartmentId = SelectedDepartmentId
            };

            Residents = await _residentRepository.GetResidentByDepartmentIdAsync(SelectedDepartmentId);
        }
    }
}