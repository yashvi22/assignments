using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.DAL.Repositories
{
    public interface IBookingRepository
    {
        string AddBooking(BookingModel model);

        string UpdateBooking(int id,BookingModel model);

        string DeleteBooking(int id);
    }
}
