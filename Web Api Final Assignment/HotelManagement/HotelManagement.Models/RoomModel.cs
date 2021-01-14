using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string Name { get; set; }

        
        public decimal Price { get; set; }
        public int isActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public virtual HotelModel Hotel { get; set; }

        public virtual CategoryModel Category { get; set; }
    }
}
