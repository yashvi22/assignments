using HotelManagement.BAL.Interfaces;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;

        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }
        
        [HttpGet]
        public IHttpActionResult GetRooms(string sortby)
        {
            
            var list = _roomManager.GetRooms();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IHttpActionResult PostRoom(RoomModel model)
        {
            var room = _roomManager.AddRoom(model);
            if (room != null)
            {
                return Ok(room);
            }
            else
            {
                return NotFound();
            }
        }
    }

}
