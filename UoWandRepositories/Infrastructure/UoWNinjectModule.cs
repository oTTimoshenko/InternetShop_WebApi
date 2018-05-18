using Ninject.Modules;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;
using UoWandRepositories.UnitOfWork;

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
            Bind<IShopUnitOfWork>().To<ShopUnitOfWork>().WithConstructorArgument("connectionString", connectionString);

            Bind<ICategoryRepository>().To<CategoryRepository>().WithConstructorArgument("connectionString", connectionString);
            Bind<IItemCharacteristicRepository>().To<ItemCharacteristicRepository>().WithConstructorArgument("connectionString", connectionString);
            Bind<IItemRepository>().To<ItemRepository>().WithConstructorArgument("connectionString", connectionString);
            Bind<IOrderRepository>().To<OrderRepository>().WithConstructorArgument("connectionString", connectionString);
        }
    }
}
