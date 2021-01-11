using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ProductManagementSystem.DAL.Repositories
{
    public interface IProductRepository
    {
        bool AddProduct(Products model);

        

        List<Products> GetProducts();

        bool DeleteProduct(int id);

        Products UpdateProduct(Products model);
    }
}
