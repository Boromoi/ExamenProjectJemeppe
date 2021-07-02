using Jemeppe.Data;
using Jemeppe.Data.Access;
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
    public class Authentication
    {
        CustomerAccess _customerAccess;
        public Authentication(CustomerAccess customerAccess)
        {
            _customerAccess = customerAccess;
        }
        /// <summary>
        /// Hash the customer password
        /// </summary>
        public static byte[] HashPassword(string password)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            using (var sha256 = new System.Security.Cryptography.SHA256Managed())
            {
                sha256.ComputeHash(data);
            }
            return data;
        }

        ///// <summary>
        ///// Validates that the customer with the specified email address has entered the correct password
        ///// </summary>
        //public bool IsValid(string email, string password)
        //{
        //    //Get the customer by email
        //    var customer = _customerAccess.GetCustomer(email);

        //    //Hash the password
        //    var hashedExpectedPassword = HashPassword(password);
        //    var hasedActualPassword = customer.PasswordHash;

        //    //Check and resturn: hashed result is equal
        //    return hashedExpectedPassword.SequenceEqual(hasedActualPassword);
        //}
    }
}
