using BlazorApp2test.Models;
using BlazorApp2test.Repositories;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2test.Services
{
    public class ResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMedicinRepository _medicinRepository;

        public ResidentService(IResidentRepository residentRepository, IMedicinRepository medicinRepository)
        {
            _residentRepository = residentRepository;
            _medicinRepository = medicinRepository;
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
            await _residentRepository.DeleteResidentAsync(resident.ResidentId);
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
        public void SetDepartment(int departmentId)
        {
            SelectedDepartmentId = departmentId;
            NewResident = new Resident
            {
                DepartmentId = departmentId
            };
        }

        public async Task LoadMedicinTimesAsync(Resident resident)
        {
            resident.MedicinTimes = await _medicinRepository.GetMedicinByResidentIdAsync(resident.ResidentId);
        }
        public async Task AddMedicinTimeAsync(Resident resident, DateTime time)
        {
            var medTime = new Medicin
            {
                ResidentID = resident.ResidentId,
                MedicinTime = time,
                MedicinCheckTimeStamp = null
            };
            await _medicinRepository.SaveNewMedicinAsync(medTime);
            await LoadMedicinTimesAsync(resident);
        }
        public async Task ToggleMedicinGivenAsync(Medicin medTime)
        {
            medTime.MedicinCheckTimeStamp = medTime.MedicinCheckTimeStamp != null ? (DateTime?)null : DateTime.Now;
            await _medicinRepository.UpdateMedicinAsync(medTime);
        }
    }
}