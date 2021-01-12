using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string SmallImage { get; set; }
        public HttpPostedFileBase SmallImg { get; set; }
        [Required]

        public string LargeImage { get; set; }
        public HttpPostedFileBase LargeImg { get; set; }

        [Required]
        public string SmallDescription { get; set; }
        [Required]
        public string LargeDescription { get; set; }
    }
}