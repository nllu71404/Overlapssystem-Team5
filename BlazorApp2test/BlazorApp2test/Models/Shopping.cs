namespace BlazorApp2test.Models
{
    public class Shopping
    {
        public int? Id { get; set; }
        public int ResidentID { get; set; }
        public string Day { get; set; } = "";
        public DateTime DateTime { get; set; }
        public string PaymentMethod { get; set; } = "";
    }
}