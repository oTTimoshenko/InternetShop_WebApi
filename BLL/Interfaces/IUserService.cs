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
        void AddItem(ItemDTO item, int quantity);
        void RemoveItem(ItemDTO item);
        void Clear();
        IEnumerable<ShoppingCart> Carts();
    }
}
