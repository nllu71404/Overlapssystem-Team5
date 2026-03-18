namespace BlazorApp2test.Models
{
    public static class ResidentHelper
    {
        public static string GetRisikoClass(Risiko risiko)
        {
            if (risiko == Risiko.Groen)
                return "risiko-groen";
            else if (risiko == Risiko.Gul)
                return "risiko-gul";
            else if (risiko == Risiko.Roed)
                return "risiko-roed";
            else
                return "";
        }
    }
}
