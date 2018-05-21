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


namespace UoWandRepositories.Infrastructure
{
    public class UoWNinjectModule : NinjectModule
    {
        private string connectionString;

        public UoWNinjectModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            //Bind<IEFshopContext>().To<EFshopContext>().InScope(x=>obj).WithConstructorArgument(connectionString);

            //Bind<DbContext>().To<EFshopContext>().WithConstructorArgument(connectionString);

            Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument("connectionString", connectionString);

            /*Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IItemCharacteristicRepository>().To<ItemCharacteristicRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();*/      
        }

        
    }
}
