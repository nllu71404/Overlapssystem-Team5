using BlazorApp2test.Models;

namespace BlazorApp2test.Services
{
    // This service class manages a list of "Borger" objects that are used in OpretISystem and BorgerSide as a way to share a list of borgere between the two components.
    public class BorgerCRUD
    {
        public List<BorgerModel> Borgere { get; } = new();
    }
}