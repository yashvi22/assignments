using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        HttpClient hc = new HttpClient();
        // GET: Products
        public ActionResult GetProducts()
        {
            List<ProductModel> list = new List<ProductModel>();
            hc.BaseAddress = new Uri("http://localhost:2200/Api/Product/GetProducts");
            var consume = hc.GetAsync("GetProducts");
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync < List <ProductModel>>();
                list = display.Result;
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            hc.BaseAddress = new Uri("http://localhost:2200/Api/Product/AddProduct");
            var consume = hc.PostAsJsonAsync("AddProduct",model);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetProducts");
            }
            else
            {
                return HttpNotFound();
            }
           
        }

        public ActionResult Delete(int id)
        {
            ProductModel product = new ProductModel();
            hc.BaseAddress = new Uri("http://localhost:2200/Api/Product/DeleteProduct");
            var consume = hc.DeleteAsync("DeleteProduct?id"+id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                ViewBag.Message = "Data Deleted Successfully";
            }
            return RedirectToAction("GetProducts");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Products product = null;
            hc.BaseAddress = new Uri("http://localhost:2200/Api/Product/UpdateProduct");
            var consume = hc.GetAsync("UpdateProduct?id" + id.ToString());
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<Products>();
                display.Wait();
                product = display.Result;
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(ProductModel model)
        {
            Products product = null;
            hc.BaseAddress = new Uri("http://localhost:2200/Api/Product/UpdateProduct");
            var consume = hc.PutAsJsonAsync<ProductModel>("UpdateProduct", model);
            consume.Wait();
            var test = consume.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("GetProducts");
            }
            return View(product);
            
        }
    }
}