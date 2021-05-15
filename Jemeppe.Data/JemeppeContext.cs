using Jemeppe.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jemeppe.Data
{
    public class JemeppeContext:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=JemeppeData");
        }

    }
}
