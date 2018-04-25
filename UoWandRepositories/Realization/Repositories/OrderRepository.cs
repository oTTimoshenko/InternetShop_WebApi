using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using Domain.Entities;


namespace UoWandRepositories.Repositories
{
    class OrderRepository: ShopGenericRepository<Order>, IOrderRepository
    {
    }
}
