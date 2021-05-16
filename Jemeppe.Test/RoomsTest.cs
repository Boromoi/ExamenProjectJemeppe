using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jemeppe.Test
{
    [TestClass]
    public class RoomsTest
    {
        [TestMethod]
        public void InsertRoom()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Rooms");
            using(var context = new Jemeppe.Data.JemeppeContext(builder.Options))
            {
                var room = new Domain.Room();
                room.Name = "De Rode Kamer";
                room.HasToilet = true;
                room.HasShower = true;
                room.HasSink = true;
                room.Price = 100.00;
                room.WebLink = @"http://en.wikipedia.org/wiki/The_Red_room";
                room.Description = "Dit is de titel van een roman van August StrindBerg";

                context.Rooms.Add(room);
                Assert.AreEqual(EntityState.Added, context.Entry(room).State);
            }
        }
    }
}
