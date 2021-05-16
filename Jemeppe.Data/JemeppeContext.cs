using Jemeppe.Domain;
using Microsoft.EntityFrameworkCore;

namespace Jemeppe.Data
{
    public class JemeppeContext:DbContext
    {
        public DbSet<Domain.Model.Room> Rooms { get; set; }
        public DbSet<Domain.Model.Booking> Bookings { get; set; }
        public DbSet<Domain.Model.Customer> Customers { get; set; }
        public JemeppeContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog=JemeppeData");
        //}

    }
}
