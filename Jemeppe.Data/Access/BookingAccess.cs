using Jemeppe.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Data.Access
{
    public class BookingAccess
    {
        JemeppeContext _context;
        CustomerAccess _customerAccess;
        RoomAccess _roomAccess;

        public BookingAccess(JemeppeContext context, CustomerAccess customerAccess, RoomAccess roomAccess)
        {
            _context = context;
            _customerAccess = customerAccess;
            _roomAccess = roomAccess;
        }

        public void CreateBooking(string emailCustomer, int roomId, DateTime startDate, DateTime endDate)
        {
            var room = _roomAccess.GetRoomById(roomId);
            var customer = _customerAccess.GetCustomer(emailCustomer);
            var booking = new Booking();
            booking.Customer = customer;
            booking.Room = room;
            booking.Startdate = DateTime.Now.AddDays(1);
            booking.Enddate = DateTime.Now.AddDays(10);
            _context.Add(booking);
            _context.SaveChanges();
        }

        public Booking[] GetAllBookings()
        {
            return _context.Bookings.Include(c => c.Customer)
                .Include(r=>r.Room)
                .ToArray();
        }
    }
}
