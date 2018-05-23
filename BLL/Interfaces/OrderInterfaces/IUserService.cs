using BLL.DTO;
using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddItem(ItemDTO item, int quantity, IShoppingCart _lineCollection);
        void RemoveItem(ItemDTO item, IShoppingCart _lineCollection);
        void Clear(IShoppingCart _lineCollection);
        IShoppingCart ComposeCart(IShoppingCart _lineCollection);
        OrderDTO MakeOrder(IShoppingCart cart);
    }
}
