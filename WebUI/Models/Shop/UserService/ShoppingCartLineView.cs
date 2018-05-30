using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class ShoppingCartLineView
    {
        public int ShoppingCartId { get; set; }
        public ItemView Item { get; set; }
        public int Quantity { get; set; }
    }
}