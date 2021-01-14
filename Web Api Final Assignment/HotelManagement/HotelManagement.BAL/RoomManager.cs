using HotelManagement.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Db;
using HotelManagement.DAL.Repositories;
using HotelManagement.Models;

namespace HotelManagement.BAL
{
    public class RoomManager : IRoomManager
    {

        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public string AddRoom(RoomModel model)
        {
            return _roomRepository.AddRoom(model);
        }

        public IQueryable<Room> GetRooms()
        {
            return _roomRepository.GetRooms();
        }
    }
}
