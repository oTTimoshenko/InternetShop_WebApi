using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;
using UoWandRepositories.Interfaces;
using UoWandRepositories.UnitOfWork;

namespace BLL.Infrastructure
{
    public class BBLNinjectModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IAdminService>().To<AdminService>();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IManageService>().To<ManageService>();
            Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
            Bind<IStatisticService>().To<StatisticService>();
            Bind<IOutputService>().To<OutputService>();
        }
    }
}
