namespace BlazorApp2test.Models
{
    public class Resident
    {
        public int ResidentId { get; set; }
        public int? DepartmentId { get; set; }
        public string Name { get; set; } = "";
        public string Status { get; set; } = "";
        public Risiko Risiko { get; set; } = Risiko.Green;

        public List<Medicin> MedicinTimes { get; set; } = new();
    }

    public enum Risiko
    {
        Green,
        Yellow,
        Red
    }
}
