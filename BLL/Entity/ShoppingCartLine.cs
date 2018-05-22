using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
namespace BLL.Entity
{
    public class ShoppingCartLine
    {
        public int ShoppingCartId { get; set; }
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}
