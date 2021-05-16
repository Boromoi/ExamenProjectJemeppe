using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jemeppe.Test
{
    [TestClass]
    public class RoomsTest
    {
        public static Domain.Model.Room CreateDummyRoom1()
        {
            var room = new Domain.Model.Room
            {
                Name = "De Rode Kamer",
                HasToilet = true,
                HasShower = true,
                HasSink = true,
                Price = 100.00,
                WebLink = @"http://en.wikipedia.org/wiki/The_Red_room",
                Description = "Dit is de titel van een roman van August StrindBerg"
            };
            return room;
        }
        [TestMethod]
        public void AddNewRoom()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Rooms");
            using(var context = new Jemeppe.Data.JemeppeContext(builder.Options))
            {
                var room = CreateDummyRoom1();
                context.Rooms.Add(room);
                Assert.AreEqual(EntityState.Added, context.Entry(room).State);
            }
        }
    }
}
