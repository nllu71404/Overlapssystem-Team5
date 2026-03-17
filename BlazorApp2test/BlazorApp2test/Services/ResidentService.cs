using BlazorApp2test.Models;

namespace BlazorApp2test.Services
{
    public class ResidentService
    {
        public List<ResidentModel> Borgere { get; } = new();

        public void RemoveBorger(ResidentModel borger)
        {
            Borgere.Remove(borger);
        }

        public void AddResident()
        {
            Borgere.Add(new ResidentModel
            {
                Id = Guid.NewGuid(),
                Navn = "Ny Borger",
                MedicinTider = "",
                PNTid = "",
                Status = "",
                Risiko = Risiko.Groen,
                Handledag = "",
                HandleTidspunkt = "",
                Betaling = 0
            });
        }
    }
}