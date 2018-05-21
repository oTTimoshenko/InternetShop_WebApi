using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ItemView
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPhotoPath { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ItemCharacteristicView ItemCharacteristic { get; set; }


        public int? CategoryId { get; set; }
        public CategoryView Category { get; set; }

        public ICollection<OrderView> Orders { get; set; }

        public ItemView()
        {
            Orders = new List<OrderView>();
        }
    }
}