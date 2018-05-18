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
    class OrderRepository : ShopGenericRepository<OrderUoW, Order>, IOrderRepository
    {
        public OrderRepository(string connectionString, IMapper mapper)
            : base(connectionString, mapper)
        { }

        public OrderUoW GetById(int id)
        {
            var entity = mapper.Map<OrderUoW>(_dbset.Include(x => x.Items).Where(x => x.OrderId == id).FirstOrDefault());
            return entity;
        }
    }
}
