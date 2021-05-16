using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Domain.Model
{
    /// <summary>
    /// Holds the booking the customer made for a certain period on a room.
    /// </summary>
    public class Booking
    {
        public Booking()
        { }

        public int Id { get; set; }

        public Room Room { get; set; }

        public int RoomId;

        public System.DateTime Startdate { get; set; }

        public System.DateTime Enddate { get; set; }
       

        public Customer Customer { get; set; }

        public int CustomerId;
    }
}