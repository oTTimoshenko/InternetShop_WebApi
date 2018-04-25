using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using Domain.Entities;
using System.Data.Entity;

namespace UoWandRepositories.Repositories
{
    public class ItemCharacteristicRepository: ShopGenericRepository<ItemCharacteristic>, IItemCharacteristicRepository
    {
        public ItemCharacteristicRepository(DbContext context)
            : base(context)
        {

        }

        public ItemCharacteristic GetById(int id)
        {
            return _dbset.Include(x => x.Item).Where(x => x.ItemCharacteristicId == id).FirstOrDefault();
        }
    }
}
