using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;
using UoWandRepositories.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IShopUnitOfWork db;
        private readonly IMapper mapper;

        public UserService(IShopUnitOfWork _db, IMapper mapper)
        {
            db = _db;
            this.mapper = mapper;
        }

        public void MakeOrder(int[] itemIds)
        {
            var items = new List<ItemDTO>();

            foreach(int index in itemIds)
            {
                var map = mapper.Map<ItemDTO>(db.Items.GetById(index));
                items.Add(map);
            }

            var order = new OrderDTO
            {
                Time = DateTime.Now,
                Items = items
            };

            var ordermapped = mapper.Map<OrderUoW>(order);

            db.Orders.Add(ordermapped);
            db.Save();
        }

    }
}
