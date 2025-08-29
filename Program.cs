using IncidentApp;
class Program
{
    static void Main()
    {
        try
        {
            var inc = new Incident("Login failure", "High", DateTime.Now.AddDays(-4));

            Console.WriteLine(inc.ToString());
            Console.WriteLine("Urgency score: " + inc.CalculateUrgency());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}