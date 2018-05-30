using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public interface IShoppingCartView
    {
        List<ShoppingCartLineView> lines { get; set; }
        double overallPrice { get; set; }
    }
}