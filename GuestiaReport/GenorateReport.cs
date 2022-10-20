using Microsoft.EntityFrameworkCore;

namespace GuestiaReport
{
    public class GenorateReport
    {
        private readonly GuestiaContext _context;

        public GenorateReport(GuestiaContext context)
        {
            _context = context;
        }

        public void GenorateTextReport()
        {
            Console.WriteLine("-------------\nGuestia Report\n-------------");

            Console.WriteLine("\nUnregistered Guests\n\nVip");
            Console.WriteLine("{0,-20} {1,5}", "Name", "Type");
            Console.WriteLine("----------------------------");

            var unregisteredGuests = _context.Guests
                .Where(q => q.RegistrationDate == null)
                .Include(q=>q.GuestGroup)
                .OrderBy(q=>q.GuestGroup.NameDisplayFormat)
                .ThenBy(q=>q.LastName)
                .ThenBy(q=>q.FirstName);

            var vips = unregisteredGuests.Where(q => q.GuestGroup.NameDisplayFormat == 0);
            foreach (var guest in vips)
                Console.WriteLine("{0,-20} {1,5:N1}", $"{guest.FirstName} {guest.LastName}", guest.GuestGroup.Name);

            Console.WriteLine("\nStandard");
            Console.WriteLine("{0,-20} {1,5}", "Name", "Type");
            Console.WriteLine("------------------------------");

            var standards = unregisteredGuests.Where(q => q.GuestGroup.NameDisplayFormat == 1);
            foreach (var guest in standards)
                Console.WriteLine("{0,-20} {1,5:N1}", $"{guest.FirstName} {guest.LastName}", guest.GuestGroup.Name);
        }
    }
}
