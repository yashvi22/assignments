using HotelManagement.DAL.Db;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public interface IRoomRepository
    {
        IQueryable<Room> GetRooms();

        string AddRoom(RoomModel model);
    }
}
