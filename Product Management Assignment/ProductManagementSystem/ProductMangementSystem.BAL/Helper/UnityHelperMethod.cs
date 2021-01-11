using ProductManagementSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace ProductMangementSystem.BAL.Helper
{
    public class UnityHelperMethod : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
