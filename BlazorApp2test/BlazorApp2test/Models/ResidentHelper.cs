namespace BlazorApp2test.Models
{
    public static class ResidentHelper
    {
        public static string GetRisikoClass(Risiko risiko)
        {
            if (risiko == Risiko.Green)
                return "risiko-green";
            else if (risiko == Risiko.Yellow)
                return "risiko-yellow";
            else if (risiko == Risiko.Red)
                return "risiko-red";
            else
                return "";
        }
    }
}
