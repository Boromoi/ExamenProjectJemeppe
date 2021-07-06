//using Jemeppe.Data.Access;
//using Jemeppe.Data.Model;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Linq;

//namespace Jemeppe.Test
//{
//    [TestClass]
//    public class RoomsTest
//    {
//        public static Data.Model.Room CreateDeRodeKamer()
//        {
//            var room = new Data.Model.Room
//            {
//                Name = "De Rode Kamer",
//                RoomType = Data.Model.RoomType.TwoPerson,
//                HasToilet = true,
//                HasShower = true,
//                HasSink = null,
//                Price = 100.00,
//                WebLink = @"http://en.wikipedia.org/wiki/The_Red_room",
//                Description = "Dit is de titel van een roman van August StrindBerg"
//            };
//            return room;
//        }
        
//        [TestMethod]
//        public void AddNewRoomTest()
//        {
//            var builder = new DbContextOptionsBuilder();
//            builder.UseInMemoryDatabase("Rooms");
//            using(var context = new Jemeppe.Data.JemeppeContext(builder.Options))
//            {
//                var room = CreateDeRodeKamer();
//                context.Rooms.Add(room);
//                Assert.AreEqual(EntityState.Added, context.Entry(room).State);
//            }
//        }

//        [TestMethod]
//        public void GetAllRoomsTest()
//        {
//            //Arrange :Create in memory database containing all rooms
//            var inMemoryBuilder = new DbContextOptionsBuilder();
//            inMemoryBuilder.UseInMemoryDatabase("GetAllRoomsTest");
//            GenerateDatabase dbGen = new GenerateDatabase(inMemoryBuilder);
            
//            using (var context = new Data.JemeppeContext(inMemoryBuilder.Options))
//            {
//                var access = new RoomAccess(context);
//                var rooms = access.GetAllRooms();

//                var roomsList = new List<Room>(rooms);

//                //Assert: Rode Kamer en Driestuiver Kamer zijn aanwezig totaal aantal kamers 8
//                Assert.IsTrue(roomsList.Count() == 8);
//                var rodeKamer = roomsList.SingleOrDefault(room => string.Equals(room.Name, "De Rode Kamer", System.StringComparison.InvariantCulture));
//                Assert.IsNotNull(rodeKamer, "De Rode Kamer was not found");
//                var drieStuiver = roomsList.SingleOrDefault(room => string.Equals(room.Name, "De Driestuivers Kamer", System.StringComparison.InvariantCulture));
//            }
//        }
//    }
//}
