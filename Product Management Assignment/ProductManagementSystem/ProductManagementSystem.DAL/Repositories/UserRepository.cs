using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Mappers;

namespace ProductManagementSystem.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PMSEntities _dbContext;
        
        public UserRepository()
        {
            _dbContext = new PMSEntities();
        }

        
        public bool CreateUser(Users model)
        {       
           if (model != null)
           {
                Users entity = new Users()
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                };                             
                _dbContext.Users.Add(entity);
                _dbContext.SaveChanges();

                return true;

                }

            return false;  
            
        }

        public int Login(UserModel model)
        {
            var user = _dbContext.Users.Where(x => x.Email == model.Email && x.Password == model.Password).FirstOrDefault();
            return model.Id;
        }
    }
}
