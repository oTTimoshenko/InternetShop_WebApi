using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime Time { get; set; } // Time of order
        public double Price { get; set; } // Total order price
        public int MyProperty { get; set; }
        public Shipment Shipment { get; set; } // shipment service
    }

    public enum Shipment
    {
        UkrPost,
        DHLPost,
        Pickup
    }
}
