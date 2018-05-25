using AutoMapper;
using BLL.DTO;
using BLL.Entity;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;

namespace BLL.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly IShopUnitOfWork db;
        private readonly IMapper mapper;

        public StatisticService(IShopUnitOfWork _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }

        public IEnumerable<OrderDTO> getAllOrders()
        {
            return mapper.Map<IEnumerable<OrderDTO>>(db.Orders.GetAll()); 
        }

        public IEnumerable<ItemDTO> getAllItems()
        {
            return mapper.Map<IEnumerable<ItemDTO>>(db.Items.GetAll());
        }

        public Statistic getOverallStats()
        {
            double ovPrice = 0.00;
            double ovItems = 0.00;
            double ovItemsSold = 0.00;

            foreach (var item in getAllOrders())
            {
                ovPrice += item.Price;
                ovItemsSold += item.Items.Count();
            }

            foreach (var item in getAllItems())
            {
                ovItems += item.Quantity;
            }

            var stat = new Statistic
            {
                totalRevenue = ovPrice,
                totalItems = ovItems,
                totalItemsSold = ovItemsSold
            };

            return stat;

        }
    }
}
