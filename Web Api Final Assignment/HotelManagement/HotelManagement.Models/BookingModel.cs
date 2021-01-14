using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class BookingModel
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int Status { get; set; }
        public  DateTime BookingDate { get; set; }

        public virtual RoomModel Room { get; set; }
    }
}
