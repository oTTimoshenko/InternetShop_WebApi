using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using Domain.Entities;
using System.Data.Entity;
using UoWandRepositories.Entities;
using AutoMapper;
using Domain.Interfaces;
namespace UoWandRepositories.Repositories
{
    public class ItemRepository: ShopGenericRepository<ItemUoW, Item>, IItemRepository
    {
        public ItemRepository(IEFshopContext context, IMapper mapper)
             : base(context, mapper)
        { }

        public ItemUoW GetById(int id)
        {
            var entity = mapper.Map<ItemUoW>(_dbset.Include(x => x.Category).Where(x => x.ItemId == id).FirstOrDefault());
            return entity;
        }
    }
}
