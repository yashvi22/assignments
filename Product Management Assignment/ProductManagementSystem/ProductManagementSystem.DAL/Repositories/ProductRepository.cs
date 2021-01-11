using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementSystem.DAL.PMS.Db;
using System.IO;
using ProductManagementSytem.Model;
using System.Web;

namespace ProductManagementSystem.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        //object of database entity class
        private readonly PMSEntities _dbContext;


        //constructor to initialize object of database entity class
        public ProductRepository(IProductRepository dbContext)
        {
            _dbContext = new PMSEntities();
        }

        //function to add product 
        public bool AddProduct(HttpPostedFileBase sfile, HttpPostedFileBase lfile, Products model)
        {
            if (model != null)
            {
                // for small image
                string sfilename = Path.GetFileName(sfile.FileName);// to get file name of the small image
                string S_extension = Path.GetExtension(sfile.FileName); // to get extension of the smal image
                sfilename = sfilename + S_extension; // concatinating the name of the file and extension 
                sfilename = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/SmallImages/"), sfilename);// path to store small image
                var S_file = sfilename; // storing path in  a variable
                

                // for large image
                string lfilename = Path.GetFileName(lfile.FileName);// to get file name of the large image
                string L_extension = Path.GetExtension(lfile.FileName); // to get extension of the large image
                lfilename = lfilename + L_extension; // concatinating the name of the file and extension 
                lfilename = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/LargeImages/"), sfilename);// path to store large image
                var L_file = lfilename; // storing path in  a variable
                

                ProductModel product = new ProductModel()
                {
                    Name= model.Name,
                    CategoryName= model.CategoryName,
                    Price=model.Price,
                    Quantity=model.Quantity,
                    SmallDescription=model.SmallDescription,
                    LargeDescription=model.LargeDescription,
                    SmallImage=S_file,
                    LargeImage=L_file
                };
                _dbContext.Products.Add(model);
                _dbContext.SaveChanges();
                return true;
            }
            return false;          
                        
        }
            

        //function to delete product
        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        // function to get list of products
        public List<Products> GetProducts()
        {
            throw new NotImplementedException();
        }


        //function to update the product
        public Products UpdateProduct(Products model)
        {
            throw new NotImplementedException();
        }
    }

       
}
