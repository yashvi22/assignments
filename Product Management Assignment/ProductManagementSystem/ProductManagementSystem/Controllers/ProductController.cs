using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using ProductMangementSystem.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : ApiController
    {
        private readonly IProductManager _productManager;

        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
       public HttpResponseMessage GetProducts()
        {
            var list = _productManager.GetProducts();
            HttpResponseMessage response;
            if (list != null)
            {
                 response = Request.CreateResponse(HttpStatusCode.OK, list);
                
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return response;
        }

        [HttpPost]
        public IHttpActionResult PostProduct(ProductModel model)
        {
            _productManager.AddProduct(model);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            _productManager.DeleteProduct(id);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult PutProduct(ProductModel model )
        {
            _productManager.UpdateProduct(model);
            return Ok();
        }
        
    }
}
