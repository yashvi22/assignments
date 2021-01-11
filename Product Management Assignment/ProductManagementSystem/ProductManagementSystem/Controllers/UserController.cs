using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using ProductMangementSystem.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProductManagementSystem.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }
        

        

        // POST: api/User
        public HttpResponseMessage Post([FromBody]Users model)
        {
            bool res = _userManager.CreateUser(model);

            if (res == true)
            {
                var showMessage = "User registered successfully";

                return Request.CreateResponse(HttpStatusCode.OK, showMessage);
            }

            else
            {
                var showMessage = "User not saved";

                return Request.CreateResponse(HttpStatusCode.BadRequest, showMessage);
            }
        }


        public int Get([FromBody]UserModel model)
        {
            var user = _userManager.Login(model);
           
                return user;
           
            
        }


    }
}