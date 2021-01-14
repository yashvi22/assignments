using HotelManagement.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using HotelManagement.DAL.Repositories;

namespace HotelManagement.BAL
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public string AddBooking(BookingModel model)
        {
            return _bookingRepository.AddBooking(model);
        }

        public string DeleteBooking(int id)
        {
            return _bookingRepository.DeleteBooking(id);
        }

        public string UpdateBooking(int id,BookingModel model)
        {
            return _bookingRepository.UpdateBooking(id, model);
        }
    }
}
