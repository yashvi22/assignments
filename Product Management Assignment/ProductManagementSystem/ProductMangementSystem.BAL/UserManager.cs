using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSystem.DAL.Repositories;
using ProductManagementSytem.Model;
using ProductMangementSystem.BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductMangementSystem.BAL
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        
        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool CreateUser(Users user)
        {
           return _userRepository.CreateUser(user);
        }

        public int Login(UserModel model)
        {
           return _userRepository.Login(model);
        }
    }
}
