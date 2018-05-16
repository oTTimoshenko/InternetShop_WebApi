using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class OrderView
    {
        public int OrderId { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public int MyProperty { get; set; }
        public ShipmentView Shipment { get; set; }

        public ICollection<ItemView> Items { get; set; }

        public OrderView()
        {
            Items = new List<ItemView>();
        }
    }

    public enum ShipmentView
    {
        UkrPost,
        DHLPost,
        Pickup
    }
}