using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using Domain.Entities;
using System.Data.Entity;
using UoWandRepositories.Entities;

namespace UoWandRepositories.Repositories
{
    class OrderRepository: ShopGenericRepository<OrderUoW>, IOrderRepository
    {
        public OrderRepository(DbContext context)
            : base(context)
        {

        }

        public OrderUoW GetById(int id)
        {
            return _dbset.Include(x => x.Items).Where(x => x.OrderId == id).FirstOrDefault();
        }
    }
}
