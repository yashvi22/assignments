using HotelManagement.DAL.Db;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.BAL.Interfaces
{
    public interface IHotelManager
    {
        List<Hotel> GetAllHotels();

        string AddHotel(HotelModel model);

        string UpdateHotel(HotelModel hotel);
    }
}
