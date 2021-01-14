using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Db;
using HotelManagement.Models;
using static HotelManagement.Constants.ConstVal;

namespace HotelManagement.DAL.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HMSEntities _dbcontext;
        public RoomRepository()
        {
            _dbcontext = new HMSEntities();
        }
        public string AddRoom(RoomModel model)
        {
            
            if (model != null)
            {
                  Room room = new Room();
                    room.HotelId = _dbcontext.Hotel.Where(x=>x.Id==model.HotelId).First().Id;
                    room.Name = model.Name;
                    room.Category = (int)Category.between51to100squaremeter;
                    room.Price = model.Price;
                    room.isActive = model.isActive;
                    room.CreatedDate = DateTime.Now;
                    _dbcontext.Room.Add(room);
                    _dbcontext.SaveChanges();
                    return "room added";

                
            }
            
            else
            {
                return "error while adding room";
            }
        }

        public IQueryable<Room> GetRooms()
        {
            var list = _dbcontext.Room.ToList().AsQueryable();
            if (list != null)
            {
                return list ;
            }
            else
            {
                return null;
            }
        }
    }
}
