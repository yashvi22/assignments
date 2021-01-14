using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DAL.Db;
using static HotelManagement.Constants.ConstVal;

namespace HotelManagement.DAL.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HMSEntities _dbcontext;

        public BookingRepository()
        {
            _dbcontext = new HMSEntities();
        }
        public string AddBooking(BookingModel model)
        {
            if (model != null)
            {
                Booking book = new Booking();
                book.RoomId = _dbcontext.Room.Where(x=>x.Id == model.RoomId).First().Id;
                book.Status = (int)Status.Optional;
                book.BookingDate = model.BookingDate;
                _dbcontext.Booking.Add(book);
                _dbcontext.SaveChanges();
                return "Booking is done successfully";
            }
            else
            {
                return "an error while booking";
            }
        }

        public string DeleteBooking(int id)
        {
            var result = _dbcontext.Booking.Where(x=>x.Id==id).FirstOrDefault();
            if (result != null)
            {
                result.Status =(int) Status.Cancelled;
                _dbcontext.SaveChanges();
                return "booking deleted successfully";
            }
            else
            {
                return "an error occurred while deleting the booking";
            }
        }

        public string UpdateBooking(int id,BookingModel model)
        {
            var booking = _dbcontext.Booking.Where(x=>x.Id==id).FirstOrDefault();
            if (booking != null)
            {
                
                booking.BookingDate = model.BookingDate;
                
                _dbcontext.SaveChanges();
                return "Booking is successfully updated";
            }
            else
            {
                return "an error occured while updating date";
            }
        }

        
    }
}
