using BlazorApp2test.Models;

namespace BlazorApp2test.Services
{
    public class ResidentService
    {
        public List<ResidentModel> BorgereSkoven { get; } = new();
        public List<ResidentModel> BorgereSlottet { get; } = new();

        public void RemoveBorgerSkoven(ResidentModel borger)
        {
            BorgereSkoven.Remove(borger);
        }
        public void RemoveBorgerSlottet(ResidentModel borger)
        {
            BorgereSlottet.Remove(borger);
        }

        public void AddResidentSkoven()
        {
            BorgereSkoven.Add(new ResidentModel
            {
                Id = Guid.NewGuid(),
                Navn = "Ny Borger",
                MedicinTider = "",
                PNTid = "",
                Status = "",
                Risiko = Risiko.Green,
                Handledag = "",
                HandleTidspunkt = "",
                Betaling = ""
            });
        }

        public void AddResidentSlottet()
        {
            BorgereSlottet.Add(new ResidentModel
            {
                Id = Guid.NewGuid(),
                Navn = "Ny Borger",
                MedicinTider = "",
                PNTid = "",
                Status = "",
                Risiko = Risiko.Green,
                Handledag = "",
                HandleTidspunkt = "",
                Betaling = ""
            });
        }
    }
}