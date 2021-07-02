using Jemeppe.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jemeppe.Data
{
    public class JemeppeContext: IdentityDbContext<Customer>
    {
        public DbSet<Data.Model.Room> Rooms { get; set; }
        public DbSet<Data.Model.Booking> Bookings { get; set; }
        public DbSet<Data.Model.Customer> Customers { get; set; }
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
