namespace BlazorApp2test.Models
{
    public class PNMedicin
    {
        public int? PNMedicinID { get; set; }
        public int ResidentID { get; set; }
        public DateTime PNTIME { get; set; }
        public string Reason { get; set; } = "";
    }
}