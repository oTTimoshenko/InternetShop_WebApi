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
    public class ItemRepository: ShopGenericRepository<Item>, IItemRepository
    {
        public ItemRepository(DbContext context)
            : base(context)
        {

        }

        public Item GetById(int id)
        {
            return _dbset.Include(x => x.Category).Where(x => x.ItemId == id).FirstOrDefault();
        }
    }
}
