using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ShoppingCartView
    {
        public ShoppingCartView()
        {
            lines = new List<ShoppingCartLineView>();
        }
        public List<ShoppingCartLineView> lines { get; set; }
        public double overallPrice { get; set; }

    }
}