using PMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace PMS.Controllers
{
    public class ProductController : Controller
    {
        PMSEntities dbcontext = new PMSEntities();

        // GET: Product
        public ActionResult Dashboard()
        {
            return View();
        }

        // add product
        public ActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            string filename1 = Path.GetFileNameWithoutExtension(model.SmallImg.FileName);
            string extension1 = Path.GetExtension(model.SmallImg.FileName);
            filename1 = filename1 + extension1;
            string rootpath = "~/Images/";
            model.SmallImage = rootpath + filename1;
            filename1 = Path.Combine(Server.MapPath("~/Images/"), filename1);
            model.SmallImg.SaveAs(filename1);


            string filename2 = Path.GetFileNameWithoutExtension(model.LargeImg.FileName);
            string extension2 = Path.GetExtension(model.LargeImg.FileName);
            filename2 = filename2 + extension2;
            model.SmallImage = rootpath + filename2;
            filename2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
            model.SmallImg.SaveAs(filename2);

            using (PMSEntities dbcontext = new PMSEntities())
            {
                Products product = new Products();
                product.Name = model.Name;
                product.CategoryName = model.CategoryName;
                product.Quantity = model.Quantity;
                product.Price = model.Price;
                product.SmallDescription = model.SmallDescription;
                product.LargeDescription = model.LargeDescription;
                dbcontext.Products.Add(product);
                dbcontext.SaveChanges();
                return RedirectToAction("GetProducts");

            }
        }

        //get list of products
        public ActionResult GetAllProducts(string sortBy, string search, int? page)
        {
            ViewBag.SortByName = string.IsNullOrEmpty(sortBy) ? "Name_desc" : "";
            ViewBag.SortByCategory = sortBy == "Category" ? "Category_desc" : "";
            ViewBag.SortByPrice = sortBy == "Price" ? "Price_desc" : "";
            var products = dbcontext.Products.AsQueryable();
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(s => s.Name.Contains(search)
                                       || s.CategoryName.Contains(search));
            }
            switch (sortBy)
            {
                case "Name_desc":
                    products = products.OrderByDescending(x => x.Name);
                    break;
                case "Category_desc":
                    products = products.OrderByDescending(x => x.CategoryName);
                    break;
                case "Price_desc":
                    products = products.OrderByDescending(x => x.Price);
                    break;
                default:
                    products = products.OrderBy(x => x.Name);
                    break;

            }
            return View(products.ToPagedList(page ?? 1, 5));
        }

        //edit products
        public ActionResult Edit(int? id)
        {
            using (PMSEntities dbcontext = new PMSEntities())
            {

                var product = dbcontext.Products.Find(id);
                Session["spath"] = product.SmallImage;
                Session["lpath"] = product.LargeImage;
                if (product != null)
                {
                    return View(product);
                }
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(ProductModel model)
        {
            string path1 = Session["spath"].ToString();
            string path2 = Session["lpath"].ToString();
            if (model.SmallImg != null && model.LargeImg != null)
            {

                string filename1 = Path.GetFileNameWithoutExtension(model.SmallImg.FileName);
                string extension1 = Path.GetExtension(model.SmallImg.FileName);
                filename1 = filename1 + extension1;
                string rootpath = "~/Images/";
                model.SmallImage = rootpath + filename1;
                filename1 = Path.Combine(Server.MapPath("~/Images/"), filename1);
                model.SmallImg.SaveAs(filename1);
                string spath1 = Request.MapPath(path1);
                if (System.IO.File.Exists(spath1))
                {
                    System.IO.File.Delete(path1);
                }
                string filename2 = Path.GetFileNameWithoutExtension(model.LargeImg.FileName);
                string extension2 = Path.GetExtension(model.LargeImg.FileName);
                filename2 = filename2 + extension2;
                model.SmallImage = rootpath + filename2;
                filename2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                model.SmallImg.SaveAs(filename2);
                string spath2 = Request.MapPath(path2);
                if (System.IO.File.Exists(spath2))
                {
                    System.IO.File.Delete(path2);
                }
            }
            if (model.SmallImg != null)
            {
                string filename1 = Path.GetFileNameWithoutExtension(model.SmallImg.FileName);
                string extension1 = Path.GetExtension(model.SmallImg.FileName);
                filename1 = filename1 + extension1;
                string rootpath = "~/Images/";
                model.SmallImage = rootpath + filename1;
                filename1 = Path.Combine(Server.MapPath("~/Images/"), filename1);
                model.SmallImg.SaveAs(filename1);
            }
            if (model.LargeImg != null)
            {
                string filename2 = Path.GetFileNameWithoutExtension(model.LargeImg.FileName);
                string extension2 = Path.GetExtension(model.LargeImg.FileName);
                filename2 = filename2 + extension2;
                string rootpath = "~/Images/";
                model.SmallImage = rootpath + filename2;
                filename2 = Path.Combine(Server.MapPath("~/Images/"), filename2);
                model.SmallImg.SaveAs(filename2);
            }
            if (model.SmallImg == null) //If small image is not edited
            {
                model.SmallImage = path1; //Take older small image 
            }
            if (model.LargeImage != path2) //If new Large Image has been inserted
            {
                string p2 = Request.MapPath(path2); //Copy the new path for Large image
                if (System.IO.File.Exists(p2)) //If older Large image exists
                {
                    System.IO.File.Delete(p2); //Delete it
                }
            }
            if (model.SmallImg == null && model.LargeImg == null) //If both the Images are null
            {
                model.SmallImage = path1; //Select older Small Image
                model.LargeImage = path2; //Select older Large Image
            }

            dbcontext.SaveChanges();
            return RedirectToAction("GetAllProducts");
        }

        public ActionResult Delete(int? id)
        {
            using(PMSEntities dbcontext=new PMSEntities())
            {
                var product = dbcontext.Products.Find(id);
                if (product != null)
                {
                    string cpath1 = Request.MapPath(product.SmallImage);
                    string cpath2 = Request.MapPath(product.LargeImage);
                    dbcontext.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                    if (dbcontext.SaveChanges() > 0)
                    {
                        if (System.IO.File.Exists(cpath1))
                        {
                            System.IO.File.Delete(cpath1);
                        }
                        if (System.IO.File.Exists(cpath2))
                        {
                            System.IO.File.Delete(cpath2);
                        }
                        return RedirectToAction("GetAllProducts");
                    }
                }
            }
        }
    }         
}
    