using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; } //Item Name
        public string ItemPhotoPath { get; set; } //Photo URL of item
        public string Description { get; set; }
        public double Price { get; set; }// Item Price
        public int Quantity { get; set; }// quantity of items in the order
        


    }
}
