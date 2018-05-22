using AutoMapper;
using BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using UoWandRepositories.Interfaces;
using BLL.Entity;
using UoWandRepositories.Entities;
using BLL.Interfaces;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private ShoppingCart lineCollection;

        public UserService()
        {
        }

        public void AddItem(ItemDTO item, int quantity)
        {
            if (item != null)
            {
                lineCollection.lines.Add(new ShoppingCartLine
                {
                    Item = item,
                    Quantity = quantity
                });
            }
        }

        public void RemoveItem(ItemDTO item)
        {
            lineCollection.lines.RemoveAll(l => l.Item.ItemId == item.ItemId);
        }

        public void Clear()
        {
            lineCollection.lines.Clear();
        }

        public IEnumerable<ShoppingCartLine> Lines
        {
            get { return lineCollection.lines; }
        }

        public ShoppingCart ComposeCart()
        {
            var cartPrice = 0.00;

            foreach (var item in lineCollection.lines)
            {
                cartPrice += item.Item.Price;
            }

            var cart = new ShoppingCart
            {
                lines = lineCollection.lines,
                overallPrice = cartPrice
            };

            return cart;
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
