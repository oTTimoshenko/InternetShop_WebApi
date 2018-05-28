using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;

namespace UoWandRepositories.Interfaces
{
    public interface IShopUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        IItemCharacteristicRepository ItemCharacteristics { get; }
        IItemRepository Items { get; }
        IOrderRepository Orders { get; }

        int Save();
    }
}
