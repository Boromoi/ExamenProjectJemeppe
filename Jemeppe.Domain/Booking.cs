using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Domain
{
    /// <summary>
    /// Holds the booking the customer made for a certain period on a room.
    /// </summary>
    public class Booking
    {

        public System.Guid Id
        {
            get => default;
            set
            {
            }
        }

        public Room Room
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime Startdate
        {
            get => default;
            set
            {
            }
        }

        public System.DateTime Enddate
        {
            get => default;
            set
            {
            }
        }

        public Customer Customer
        {
            get => default;
            set
            {
            }
        }
    }
}