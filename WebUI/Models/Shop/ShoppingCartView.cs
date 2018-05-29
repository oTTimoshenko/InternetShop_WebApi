using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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