using AutoMapper;
using BLL.DTO;
using System.Collections.Generic;
using System.Linq;
using UoWandRepositories.Interfaces;
using BLL.Entity;

namespace BLL.Services
{
    public class UserService 
    {
        //private readonly IShopUnitOfWork db;
        //private readonly IMapper mapper;

        private List<ShoppingCart> cartCollection;

        public UserService()
        {
            //db = _db;
            //this.mapper = mapper;
            cartCollection = new List<ShoppingCart>();
        }

        public void AddItem(ItemDTO item, int quantity)
        {
            ShoppingCart cart = cartCollection
                .Where(p => p.Item.ItemId == item.ItemId)
                .FirstOrDefault();

            if (cart == null)
            {
                cartCollection.Add(new ShoppingCart
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else
            {
                cart.Quantity += quantity;
            }
        }

        public void RemoveItem(ItemDTO item)
        {
            cartCollection.RemoveAll(l => l.Item.ItemId == item.ItemId);
        }

        public void Clear()
        {
            cartCollection.Clear();
        }

        public IEnumerable<ShoppingCart> Carts
        {
            get { return cartCollection; }
        }




        //public void MakeOrder(int[] itemIds)
        //{
        //    var items = new List<ItemDTO>();

        //    foreach(int index in itemIds)
        //    {
        //        var map = mapper.Map<ItemDTO>(db.Items.GetById(index));
        //        items.Add(map);
        //    }

        //    var order = new OrderDTO
        //    {
        //        Time = DateTime.Now,
        //        Items = items
        //    };

        //    var ordermapped = mapper.Map<OrderUoW>(order);

        //    db.Orders.Add(ordermapped);
        //    db.Save();
        //}

    }
}
