using ProductManagementSystem.DAL.PMS.Db;
using ProductManagementSytem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementSystem.DAL.Repositories
{
    public interface IUserRepository
    {
        bool CreateUser(Users model);

        int Login(UserModel model);
    }
}
