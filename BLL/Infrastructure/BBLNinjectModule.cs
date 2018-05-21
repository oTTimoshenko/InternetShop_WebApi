using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
