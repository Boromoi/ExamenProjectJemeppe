using Jemeppe.Data;
using Jemeppe.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Domain.Logic
{
    public class CustomerSupport
    {
        JemeppeContext _context;
        public CustomerSupport(JemeppeContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Hash the customer password
        /// </summary>
        public static byte[] HashPassword(string password)
        {
            byte[] data = new byte[256];
            byte[] result;
            SHA256 shaM = new SHA256Managed();
            result = shaM.ComputeHash(data);
            return result;
        }

        public Customer GetCustomer(string email)
        {
            return _context.Customers.Single(c => string.Equals(c.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
