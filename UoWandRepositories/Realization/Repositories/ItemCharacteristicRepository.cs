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

namespace UoWandRepositories.Repositories
{
    public class ItemCharacteristicRepository: ShopGenericRepository<ItemCharacteristicUoW, ItemCharacteristic>, IItemCharacteristicRepository
    {
        public ItemCharacteristicRepository(string connectionString, IMapper mapper)
             : base(connectionString, mapper)
        { }

        public ItemCharacteristicUoW GetById(int id)
        {
            var entity = mapper.Map<ItemCharacteristicUoW>(_dbset.Include(x => x.Item).Where(x => x.ItemCharacteristicId == id).FirstOrDefault());
            return entity;
        }
    }
}
