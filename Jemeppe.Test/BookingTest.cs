using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Test
{
    [TestClass]
    public class BookingTest
    {
        public static Data.Model.Booking CreateDummyBooking1(Data.Model.Customer customer, Data.Model.Room room)
        {
            var booking = new Data.Model.Booking();
            booking.Customer = customer;
            booking.Room = room;
            booking.Startdate = DateTime.Now.AddDays(1);
            booking.Enddate = DateTime.Now.AddDays(10);
            return booking;
        }

        [TestMethod]
        public void CreateANewBooking()
        {
            var room = RoomsTest.CreateDummyRoom1();
            var customer = CustomerTest.CreateDummyCustomer1();

            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Booking");
            using (var context = new Jemeppe.Data.JemeppeContext(builder.Options))
            {
                var booking = CreateDummyBooking1(customer, room);
                context.Bookings.Add(booking);
                Assert.AreEqual(EntityState.Added, context.Entry(room).State);
            }
        }
    }
}
