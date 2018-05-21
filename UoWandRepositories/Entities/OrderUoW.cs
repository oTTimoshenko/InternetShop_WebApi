using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities
{
    public  class OrderUoW
    {
        public int OrderId { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public ShipmentUoW Shipment { get; set; }
        public StateUoW State { get; set; }

        public ICollection<ItemUoW> Items { get; set; }

        public OrderUoW()
        {
            Items = new List<ItemUoW>();
        }
    }

    public enum ShipmentUoW
    {
        UkrPost,
        DHLPost,
        Pickup
    }

    public enum StateUoW
    {
        Confirmed,
        In_process,
        Declined
    }
}
