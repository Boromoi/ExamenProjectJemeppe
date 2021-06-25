using Jemeppe.Domain.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Test
{
    [TestClass]
    public class CustomerTest
    {
        public static Data.Model.Customer CreateDummyCustomer1()
        {
            var hashed = Domain.Logic.CustomerSupport.HashPassword("MijGeheim001");

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
        public void AddNewCustomer()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Customers");
            using (var context = new Data.JemeppeContext(builder.Options))
            {
                var customer = CreateDummyCustomer1();
                context.Customers.Add(customer);
                Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
            }
        }

        [TestMethod]
        public void GetCustomerByEmail()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Customers");
            using (var context = new Data.JemeppeContext(builder.Options))
            { 
                //Add customer with email "Piet.Klaasen@hotmail.com"
                var support = new CustomerSupport(context);
                var customer = CreateDummyCustomer1();
                context.Customers.Add(customer);
                context.SaveChanges();

                //Retrieve customer with email "Piet.Klaasem@hotmail.com
                var result = support.GetCustomer("Piet.Klaasen@hotmail.com");
                
                //Assert Customer data is as expected
                Assert.IsTrue(string.Equals(result.Name, "Piet Klaasen"));
            }
        }

        [TestMethod]
        public void HashPassword()
        {
            var hashed = CustomerSupport.HashPassword("MijGeheim001");
            Assert.IsNotNull(hashed);
        }
    }
}
