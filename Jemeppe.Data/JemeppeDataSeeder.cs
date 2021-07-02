using Jemeppe.Data.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Data
{
    public class JemeppeDataSeeder
    {
        JemeppeContext _context;
        UserManager<Customer> _userManager;

        public JemeppeDataSeeder(JemeppeContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //if the database is filled just return;
            if (_context.Rooms.Any())
                return;

            //Add all hotel rooms
            foreach (var room in CreateRooms())
            {
                _context.Add(room);
            }

            _context.SaveChanges();
            
            //Add default admin account
            Customer admin = new Customer();
            admin.Email = "liamvanslingerlandt@hotmail.nl";
            admin.UserName = admin.Email;
            var result = await _userManager.CreateAsync(admin, "P@ssw0rd!");

            if (result != IdentityResult.Success)
                throw new InvalidOperationException("Could not create new user");
        }

        public static List<Data.Model.Room> CreateRooms()
        {
            List<Data.Model.Room> result = new List<Data.Model.Room>();
            result.Add(CreateRoom("De Rode Kamer", Data.Model.RoomType.TwoPerson, true, true, true, 100.00, @"https://en.wikipedia.org/wiki/The_Red_Room_(Strindberg_novel)", "Dit is de titel van een roman van August StrindBerg ([weblink]). De kamer is in zachtrood geverfd en biedt plaats aan twee personen."));
            result.Add(CreateRoom("De Avonden Kamer", Data.Model.RoomType.TwoPerson, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/De_avonden_%28boek%29", "Dit is de titel van een roman van Gerard Reve ([weblink]). De kamer ligt op het westen en men kan hier genieten van de mooie zonsondergangen."));
            result.Add(CreateRoom("De Versierde Kamer", Data.Model.RoomType.OnePerson, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/Harry_Mulisch", "Deze kamer is vernoemd naar \"De versierde mens\" van Harry Mulisch ([weblink]) Overheersend in deze kamer zijn de kleuren van het water."));
            result.Add(CreateRoom("De Derde Kamer", Data.Model.RoomType.Family, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/Jan_Terlouw", "Deze kamer, genoemd naar een roman van Jan Terlouw ([weblink]), is geschikt voor alle mensen van alle gezindten"));
            result.Add(CreateRoom("De Donkere Kamer", Data.Model.RoomType.OnePerson, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/Willem_Frederik_Hermans", "Deze kamer, genaamd naar de roman van W.F. Hermans ([weblink]), De donkere kamer van Damocles, ligt op het noorden en doet daardoor zijn naam eer aan."));
            result.Add(CreateRoom("De Opperlandse Kamer", Data.Model.RoomType.Family, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/Hugo_Brandt_Corstius", "De Opperlandse Kamer Deze kamer genoemd naar De Opperlandse taal - en letterkunde van Battus ([weblink]), is vooral geschikt voor vakantiegangers, tenslotte het Opperlands is Nederlands met vakantie."));
            result.Add(CreateRoom("De Driestuivers Kamer", Data.Model.RoomType.OnePerson, true, false, false, 85.00, @"https://nl.wikipedia.org/wiki/Bertolt_Brecht", "Dit is de eenvoudigste kamer van het kasteel en is dus niet voor niets genoemd naar de Dreigröschenoper van Bertold Brecht. ([weblink])"));
            result.Add(CreateRoom("De Geheime Kamer", Data.Model.RoomType.Undefined, null, null, null, 100.00, @"https://nl.wikipedia.org/wiki/J.K._Rowling", "De Geheime Kamer Van deze kamer, genoemd naar \"the Chamber of Secrets\" van Joanne Rowling ([weblink]), is alleen de prijs bekend."));
            return result;
        }
        public static Data.Model.Room CreateRoom(string name, Data.Model.RoomType roomType, bool? hasToilet, bool? hasShower, bool? hasSink, double price, string webink, string description)
        {
            var room = new Data.Model.Room
            {
                Name = name,
                RoomType = roomType,
                HasToilet = hasToilet,
                HasShower = hasShower,
                HasSink = hasSink,
                Price = price,
                WebLink = webink,
                Description = description
            };
            return room;
        }
    }
}
