using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Domain.Model
{
    /// <summary>
    /// Customer information
    /// </summary>
    public class Customer
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int Id { get; set; }
        
        public List<Booking> Bookings { get; set; }
    }
}