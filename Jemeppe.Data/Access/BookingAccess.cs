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

        public async void CreateBooking(string emailCustomer, int roomId, DateTime startDate, DateTime endDate)
        {
            var customer = await _customerAccess.GetCustomer(emailCustomer);
            var room = _roomAccess.GetRoomById(roomId);

            var booking = new Data.Model.Booking();
            booking.Customer = customer;
            booking.Room = room;
            booking.Startdate = DateTime.Now.AddDays(1);
            booking.Enddate = DateTime.Now.AddDays(10);
        }
    }
}
