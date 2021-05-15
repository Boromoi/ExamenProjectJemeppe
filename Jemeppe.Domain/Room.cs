using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Domain
{
    /// <summary>
    /// Holds the information of the hotel room
    /// </summary>
    public class Room
    {
        public RoomType RoomType
        {
            get => default;
            set
            {
            }
        }

        public bool HasToilet
        {
            get => default;
            set
            {
            }
        }

        public bool HasShower
        {
            get => default;
            set
            {
            }
        }

        public bool HasSink
        {
            get => default;
            set
            {
            }
        }

        public double Price
        {
            get => default;
            set
            {
            }
        }

        public string Name
        {
            get => default;
            set
            {
            }
        }

        public string Description
        {
            get => default;
            set
            {
            }
        }

        public string WebLink
        {
            get => default;
            set
            {
            }
        }

        public System.Guid Id
        {
            get => default;
            set
            {
            }
        }

        public List<Booking> Bookings
        {
            get => default;
            set
            {
            }
        }
    }
}