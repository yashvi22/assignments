using ProductMangementSystem.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSystem.DAL.Repositories;
using ProductManagementSytem.Model;

namespace ProductMangementSystem.BAL
{
    
    public class ProductManager : IProductManager
    {
        private readonly IProductRepository _productRepository;

        public ProductManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public bool AddProduct(Products model)
        {
            return _productRepository.AddProduct(model);
        }

        public bool DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

      

        public List<Products> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Products UpdateProduct(Products model)
        {
            return _productRepository.UpdateProduct(model);
        }
    }
}
