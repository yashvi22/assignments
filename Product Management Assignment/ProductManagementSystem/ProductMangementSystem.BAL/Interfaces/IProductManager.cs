using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementSystem.BAL.Interfaces
{
    public interface IProductManager
    {
        bool AddProduct(Products model);

        

        List<Products> GetProducts();

        bool DeleteProduct(int id);

        Products UpdateProduct(Products model);
    }
}
