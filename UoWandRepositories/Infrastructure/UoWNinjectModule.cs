using Ninject.Modules;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;

namespace UoWandRepositories.Infrastructure
{
    public class UoWNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IItemCharacteristicRepository>().To<ItemCharacteristicRepository>();
            Bind<IItemRepository>().To<ItemRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
        }
    }
}
