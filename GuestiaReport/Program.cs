using GuestiaReport;

namespace ConnectingToSQLServer
{
    class Program
    {
        private static GenorateReport report;

        private static void Main(string[] args)
        {
            var context = new GuestiaContext();
            report = new GenorateReport(context);

            report.GenorateTextReport();
            Console.ReadLine();
        }
    }
}