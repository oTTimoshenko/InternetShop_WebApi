using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Entities;
using BLL.Interfaces;
using BLL.DTO;

namespace BLL.Services
{
    public class ManageService : IManageService
    {
        private readonly IShopUnitOfWork db;
        private readonly IMapper mapper;

        public ManageService(IShopUnitOfWork _db, IMapper mapper)
        {
            db = _db;
            this.mapper = mapper;
        }

        //public void ConfirmOrder(int id)
        //{
        //    var order = db.Orders.GetById(id);
        //    order.State = StateUoW.Confirmed;
        //    db.Orders.Edit(order);
        //    db.Save();
        //}
        //public void DeclineOrder(int id)
        //{
        //    var order = db.Orders.GetById(id);
        //    order.State = StateUoW.Declined;
        //    db.Orders.Edit(order);
        //    db.Save();
        //}
        public void UpdateOrder(OrderDTO order)
        {
            var _order = mapper.Map<OrderUoW>(order);
            db.Orders.Edit(_order);
            db.Save();
        }
        public OrderDTO GetOrder(int Id)
        {
            return mapper.Map<OrderDTO>(db.Orders.GetById(Id));
        }
    }
}
