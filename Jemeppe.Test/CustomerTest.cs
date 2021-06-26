using Jemeppe.Data.Access;
using Jemeppe.Domain.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Test
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class CustomerTest
    {
        public static Data.Model.Customer CreateNewCustomer()
        {
            var hashed = Domain.Logic.Authentication.HashPassword("MijGeheim001");

            var customer = new Data.Model.Customer
            {
                Address = "Kerkstraat 23, Amsterdam",
                Email = "Piet.Klaasen@hotmail.com",
                Name = "Piet Klaasen",
                PasswordHash = hashed,
                PhoneNumber = "1234567890"
            };
            return customer;
        }

        [TestMethod]
        public void AddNewCustomerSuccess()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AddNewCustomerSuccess");
            using (var context = new Data.JemeppeContext(builder.Options))
            {
                var customer = CreateNewCustomer();
                context.Customers.Add(customer);
                Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
            }
        }

        [TestMethod]
        public void GetCustomerByEmailSuccess()
        {
            //Arrange: Create a user in the databsae with an email address
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("GetCustomerByEmailSuccess");
            using (var context = new Data.JemeppeContext(builder.Options))
            { 
                var support = new CustomerAccess(context);
                var customer = CreateNewCustomer();
                context.Customers.Add(customer);
                context.SaveChanges();

                //Act: Retrieve customer with email "Piet.Klaasem@hotmail.com
                var result = support.GetCustomer("Piet.Klaasen@hotmail.com");
                
                //Assert: Customer data is as expected
                Assert.IsTrue(string.Equals(result.Name, "Piet Klaasen"));
            }
        }

        [TestMethod]
        public void HashPasswordSuccess()
        {
            //Arrange Set up a password
            var password = "MijGeheim001";

            //Act Hash the Password
            var hashed = Authentication.HashPassword(password);

            //Assert The password is now a valid byte array
            Assert.IsNotNull(hashed);
            Assert.IsTrue(hashed.Length > 1);
        }

        [TestMethod]
        public void HashDifferentPasswordsGiveDifferentResults()
        {
            var password1 = "Geheim123456";
            var password2 = "12345Geheim";
            var hashed1 = Authentication.HashPassword(password1);
            var hashed2 = Authentication.HashPassword(password2);

            var result = hashed1.SequenceEqual(hashed2);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AuthenticateSuccess()
        {
            //Arrange: Create a valid Customer with an Email and a hased password
            var password = "HetGeheimePassword";
            var email = "onevalidemail@hotmail.com";
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AuthenticateSuccess");
            using (var context = new Data.JemeppeContext(builder.Options))
            {
                var customer = CreateNewCustomer();
                customer.Email = email;
                customer.PasswordHash = Authentication.HashPassword(password);
                context.Customers.Add(customer);
                context.SaveChanges();

                //Act: Pass the email and an unhashed password to the authentication
                var customerAcess = new Jemeppe.Data.Access.CustomerAccess(context);
                var authentication = new Domain.Logic.Authentication(customerAcess);
                var result = authentication.IsValid(email, password);

                //Assert: The authentication is successfull
                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void AuthenticateNotSuccess()
        {
            //Arrange: Create a valid Customer with an Email and a hased password
            var password = "HetGeheimePassword";
            var wrongPassword = "VerkeerdGeheimPassword";
            var email = "onevalidemail@hotmail.com";
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("AuthenticateNotSuccess");
            using (var context = new Data.JemeppeContext(builder.Options))
            {
                var customer = CreateNewCustomer();
                customer.Email = email;
                customer.PasswordHash = Authentication.HashPassword(password);
                context.Customers.Add(customer);
                context.SaveChanges();

                //Act: Pass the email and an unhashed password to the authentication
                var customerAcess = new Jemeppe.Data.Access.CustomerAccess(context);
                var authentication = new Domain.Logic.Authentication(customerAcess);
                var result = authentication.IsValid(email, wrongPassword);

                //Assert: The authentication is successfull
                Assert.IsFalse(result);
            }
        }
    }
}
