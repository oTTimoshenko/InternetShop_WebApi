using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            lines = new List<ShoppingCartLine>();
        }
        public List<ShoppingCartLine> lines { get; set; }
        public double overallPrice { get; set; }

    }
}
