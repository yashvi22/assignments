using HotelManagement.BAL.Interfaces;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class HotelController : ApiController
    {
        
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {
            _hotelManager = hotelManager;
        }

        
        [HttpGet]
        public IHttpActionResult GetHotels(string search )
        {
            
            var list = _hotelManager.GetAllHotels().AsQueryable().OrderBy(search);
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

       
        //to add hotel
        [HttpPost]
        public IHttpActionResult PostHotel(HotelModel model)
        {
            var result = _hotelManager.AddHotel(model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        
        [HttpPut]
        public IHttpActionResult PutHotel(HotelModel model)
        {
            var result = _hotelManager.UpdateHotel(model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        
    }
}
