using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Data.Model
{
    /// <summary>
    /// Holds the information of the hotel room
    /// </summary>
    public class Room
    {
        public RoomType RoomType { get; set; }


        public bool HasToilet { get; set; }


        public bool HasShower { get; set; }


        public bool HasSink { get; set; }


        public double Price { get; set; }


        public string Name { get; set; }


        public string Description { get; set; }


        public string WebLink { get; set; }


        public int Id { get; set; }


        public List<Booking> Bookings { get; set; }
        
    }
}