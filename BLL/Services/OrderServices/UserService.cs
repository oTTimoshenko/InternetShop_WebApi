using AutoMapper;
using BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using UoWandRepositories.Interfaces;
using BLL.Entity;
using UoWandRepositories.Entities;
using BLL.Interfaces;
using System;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IShopUnitOfWork _db;
        private readonly IMapper _mapper;

        public UserService(IShopUnitOfWork db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public bool AddItem(ItemDTO item, int quantity, IShoppingCart _lineCollection)
        {
            try
            {
                if (item != null)
                {
                    _lineCollection.lines.Add(new ShoppingCartLine
                    {

                        Item = _mapper.Map<ItemDTO>(_db.Items.GetById(item.ItemId)),
                        Quantity = quantity
                    });
                }
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;

        }

        public bool RemoveItem(ItemDTO item, IShoppingCart _lineCollection)
        {
            try
            {
                _lineCollection.lines.RemoveAll(l => l.Item.ItemId == item.ItemId);
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool Clear(IShoppingCart _lineCollection)
        {
            try
            {
                _lineCollection.lines.Clear();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }


        public IShoppingCart ComposeCart(IShoppingCart _lineCollection)
        {
            var cartPrice = 0.00;

            foreach (var item in _lineCollection.lines)
            {
                cartPrice += item.Item.Price;
            }

            var cart = new ShoppingCart
            {
                lines = _lineCollection.lines,
                overallPrice = cartPrice

            };

            return cart;
        }

        public OrderDTO MakeOrder(IShoppingCart cart)
        {
            List<ItemDTO> items = new List<ItemDTO>();
            foreach (var item in cart.lines)
            {
                items.Add(item.Item);
            }
            var order = new OrderDTO
            {
                Items = items,
                Time = System.DateTime.Now,
                Price = cart.overallPrice,
                State = StateDTO.In_process
                
            };
            return order;
        }



        //public void MakeOrder(int[] itemIds)
        //{
        //    var items = new List<ItemDTO>();

        //    foreach (int index in itemIds)
        //    {
        //        var map = mapper.Map<ItemDTO>(db.Items.GetById(index));
        //        items.Add(map);
        //    }
        //    var orders = new List<OrderUoW>();
        //    double checkpay = 0.00;

        //    foreach (var item in items)
        //    {
        //        //orders.Add(new OrderUoW );
        //    }

        //    var order = new OrderDTO
        //    {
        //        Time = System.DateTime.Now,
        //        Items = items
        //    };

        //    var ordermapped = mapper.Map<OrderUoW>(order);

        //    db.Orders.Add(ordermapped);
        //    db.Save();
        //}

    }
}
