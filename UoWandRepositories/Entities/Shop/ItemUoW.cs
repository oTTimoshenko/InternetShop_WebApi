using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities
{
    public class ItemUoW
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPhotoPath { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ItemCharacteristicUoW ItemCharacteristic { get; set; }


        public int? CategoryId { get; set; }
        public CategoryUoW Category { get; set; }

        public ICollection<OrderUoW> Orders { get; set; }

        public ItemUoW()
        {
            Orders = new List<OrderUoW>();
        }
    }
}
