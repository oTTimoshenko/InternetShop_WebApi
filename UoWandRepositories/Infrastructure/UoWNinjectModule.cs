using Domain.Context;
using Domain.Interfaces;
using Ninject;
using Ninject.Modules;
using System.Data.Entity;
using UoWandRepositories.Entities;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;
using UoWandRepositories.UnitOfWork;
using Ninject.Parameters;
using UoWandRepositories.Interfaces.Account;
using UoWandRepositories.Realization.UnitOfWork;

namespace UoWandRepositories.Infrastructure
{
    public class UoWNinjectModule : NinjectModule
    {
        private string ShopConnectionString;
        private string AccountConnectionString;


        public UoWNinjectModule(string ShopConnectionString, string AccountConnectionString)
        {
            this.ShopConnectionString = ShopConnectionString;
            this.AccountConnectionString = AccountConnectionString;
        }

        public override void Load()
        {
            //Bind<IEFshopContext>().To<EFshopContext>().InScope(x=>obj).WithConstructorArgument(connectionString);

            //Bind<DbContext>().To<EFshopContext>().WithConstructorArgument(connectionString);

            Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument("connectionString", ShopConnectionString);
            Bind<IAccountUnitOfWork>().To<AccountUnitOfWork>().WithConstructorArgument("connectionString", AccountConnectionString);

            /*Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IItemCharacteristicRepository>().To<ItemCharacteristicRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();*/
        }


    }
}
