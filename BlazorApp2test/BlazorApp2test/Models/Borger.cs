namespace BlazorApp2test.Models
{
    public class BorgerModel
    {
        public string Navn { get; set; } = "";
        public string MedicinTider { get; set; } = "";
        public string PNTid { get; set; } = "";
        public string Status { get; set; } = "";
        public Risiko Risiko { get; set; } = Risiko.Groen;
        public string Handledag { get; set; } = "";
        public string HandleTidspunkt { get; set; } = "";
        public decimal Betaling { get; set; } = 0;
    }

    public enum Risiko
    {
        Groen,
        Gul,
        Roed
    }
}
