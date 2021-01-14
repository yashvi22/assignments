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
    public class BookingController : ApiController
    {
        private readonly IBookingManager _bookingManager;
        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        } 

        [HttpPost]
        public  IHttpActionResult PostBooking(BookingModel model)
        {
            var result = _bookingManager.AddBooking(model);
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
        public IHttpActionResult PutBooking(int id,BookingModel model)
        {
            var result = _bookingManager.UpdateBooking(id, model);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteBooking(int id)
        {
            var result = _bookingManager.DeleteBooking(id);
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
