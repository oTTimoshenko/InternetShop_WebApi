using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using UoWandRepositories.Interfaces;
using UoWandRepositories.UnitOfWork;

namespace BLL.Infrastructure
{
    public class BBLNinjectModule:NinjectModule
    {
        private string connectionString;
        public BBLNinjectModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
