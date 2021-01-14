using HotelManagement.DAL.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.Models;
using System.Data.Entity;

namespace HotelManagement.DAL.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HMSEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new HMSEntities();
        }

        //to add hotel
        public string AddHotel(HotelModel model)
        {
            if (model != null)
            {
                Hotel hotel = new Hotel();
                hotel.Name = model.Name;
                hotel.Address = model.Address;
                hotel.City = model.City;
                hotel.Pincode = model.Pincode;
                hotel.ContactNo = model.ContactNo;
                hotel.ContactPersonName = model.ContactPersonName;
                hotel.Website = model.Website;
                hotel.Facebook = model.Facebook;
                hotel.Twitter = model.Twitter;
                hotel.isActive = model.isActive;
                hotel.CreatedDate = DateTime.Now;

                _dbContext.Hotel.Add(hotel);
                _dbContext.SaveChanges();
                return "Hotel Added Successfully";
            }
            else
            {
                return "An error occured";
            }
        }

        // to get all hotel
        public List<Hotel> GetAllHotels()
        {
            var list = _dbContext.Hotel.ToList();
            return list;
        }

        public string UpdateHotel(HotelModel model)
        {
            var entity = _dbContext.Hotel.Find(model.Id);
            if (entity != null)
            {
                
                entity.Name = model.Name;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.Pincode = model.Pincode;
                entity.ContactNo = model.ContactNo;
                entity.ContactPersonName = model.ContactPersonName;
                entity.Website = model.Website;
                entity.Facebook = model.Facebook;
                entity.Twitter = model.Twitter;
                entity.isActive = model.isActive;
                entity.UpdatedDate = DateTime.Now;

                
                _dbContext.SaveChanges();
                return "Hotel Updated Successfully";
            }

            else
            {
                return "Can't find the hotel";
            }
        }



    }
}
