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
    public class ItemCharacteristicRepository: ShopGenericRepository<ItemCharacteristicUoW, ItemCharacteristic>, IItemCharacteristicRepository
    {
        public ItemCharacteristicRepository(IEFshopContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public ItemCharacteristicUoW GetById(int id)
        {
            var entity = mapper.Map<ItemCharacteristicUoW>(_dbset.Include(x => x.Item).Where(x => x.ItemCharacteristicId == id).FirstOrDefault());
            return entity;
        }
    }
}
