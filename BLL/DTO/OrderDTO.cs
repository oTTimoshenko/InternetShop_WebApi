using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; } 
        public int MyProperty { get; set; }
        public ShipmentDTO Shipment { get; set; } 

        public ICollection<ItemDTO> Items { get; set; }

        public OrderDTO()
        {
            Items = new List<ItemDTO>();
        }
    }

    public enum ShipmentDTO
    {
        UkrPost,
        DHLPost,
        Pickup
    }
}
