using System.Collections.Generic;

namespace BLL.DTO
{
    public class ItemDTO
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; } 
        public string ItemPhotoPath { get; set; } 
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public ItemCharacteristicsDTO ItemCharacteristic { get; set; }


        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }

        public ICollection<OrderDTO> Orders { get; set; }

        public ItemDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}
