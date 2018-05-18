using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;

namespace UoWandRepositories.Interfaces
{
    public interface IOrderRepository: IShopGenericRepository<OrderUoW, Order>
    {
        OrderUoW GetById(int id);
    }
}
