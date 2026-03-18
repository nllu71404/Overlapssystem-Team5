namespace BlazorApp2test.Models
{
    public class ResidentModel
    {
        public Guid Id { get; set; }
        public string Navn { get; set; } = "";
        public string MedicinTider { get; set; } = "";
        public string PNTid { get; set; } = "";
        public string Status { get; set; } = "";
        public Risiko Risiko { get; set; } = Risiko.Green;
        public string Handledag { get; set; } = "";
        public string HandleTidspunkt { get; set; } = "";
        public string Betaling { get; set; } = "";
    }

    public enum Risiko
    {
        Green,
        Yellow,
        Red
    }
}
