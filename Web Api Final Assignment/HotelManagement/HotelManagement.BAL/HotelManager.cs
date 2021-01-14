using HotelManagement.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.DAL.Db;
using HotelManagement.DAL.Repositories;
using HotelManagement.Models;

namespace HotelManagement.BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string AddHotel(HotelModel model)
        {
           var result=_hotelRepository.AddHotel(model);
            return result;
        }

        public List<Hotel> GetAllHotels()
        {
            var list = _hotelRepository.GetAllHotels();
            return list;
        }

        public string UpdateHotel(HotelModel hotel)
        {
            var result=_hotelRepository.UpdateHotel(hotel);
            return result;
        }
    }
}
