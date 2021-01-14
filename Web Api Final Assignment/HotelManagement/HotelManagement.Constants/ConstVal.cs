using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Constants
{
    public class ConstVal
    {
        public enum Category{Lessthan35sqauremeters=1,Between35and50squaremeter=2,between51to100squaremeter=3}
        public enum Status { Optional=1,Definitive=2,Cancelled=3,Deleted=4}
    }
}
