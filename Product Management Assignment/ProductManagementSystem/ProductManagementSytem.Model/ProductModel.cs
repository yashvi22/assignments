using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSytem.Model
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [StringLength(30,ErrorMessage ="Name should not be more than 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please select category")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage ="Please enter price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Please upload a image")]
        public string SmallImage { get; set; }

        [Required(ErrorMessage ="Please upload a image")]
        public string LargeImage { get; set; }

        [Required(ErrorMessage ="Please enter Quantity")]
        public int Quantity { get; set; }

        [Required(ErrorMessage ="Please enter small description")]
        [StringLength(50,ErrorMessage ="It should be not more than 50 characters")]
        public string SmallDescription { get; set; }

        [Required(ErrorMessage ="Please enter description")]
        [StringLength(200)]
        public string LargeDescription { get; set; }

        
    }
}
