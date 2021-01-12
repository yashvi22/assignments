using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS.Controllers
{
    public class UserApiController : ApiController
    {
        public IHttpActionResult PostUser(Users Model)

        {
            using(PMSEntities dbContext= new PMSEntities())
            {
                dbContext.Users.Add(Model);

                return Ok();
            }

        }
    }
}
