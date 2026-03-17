using BlazorApp2test.Models;

namespace BlazorApp2test.Services
{
    // This service class manages a list of "Borger" objects that are used in OpretISystem and BorgerSide as a way to share a list of borgere between the two components.
    public class ResidentServices
    {
        public List<ResidentModel> Borgere { get; } = new();

        // Is used on BorgerSide to remove a selected borger from the list of borgere.
        public void RemoveBorger(ResidentModel borger)
        {
            Borgere.Remove(borger);
        }
    }
}