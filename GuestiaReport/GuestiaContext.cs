using Microsoft.EntityFrameworkCore;
using GuestiaReport.Models;

namespace GuestiaReport
{
    public class GuestiaContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestGroup> GuestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\MSSQLSERVER01;Database=GuestiaDB;Trusted_Connection=True;");
        }
    }
}
