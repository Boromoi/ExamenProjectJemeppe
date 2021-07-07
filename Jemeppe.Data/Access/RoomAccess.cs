using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Data.Access
{
    /// <summary>
    /// Contains all data access methods needed for Create Read Update and Delete of Rooms
    /// </summary>
    public class RoomAccess
    {
        JemeppeContext _context;
        public RoomAccess(JemeppeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the rooms available in the database
        /// </summary>
        public Model.Room[] GetAllRooms()
        {
            return _context.Rooms.ToArray();
        }

        internal Model.Room GetRoomById(int roomId)
        {
            return _context.Rooms.Single(r => r.Id == roomId);
        }
    }
}
