using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult GetHotel()
        {
            return Ok();
        }
    }
}
