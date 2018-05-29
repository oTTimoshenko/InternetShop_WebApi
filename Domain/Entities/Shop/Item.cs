using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимая длина названия товара")]
        public string ItemName { get; set; } //Item Name

        public string ItemPhotoPath { get; set; } //Photo URL of item

        [Required]
        [StringLength(250, MinimumLength = 30, ErrorMessage = "Недопустимая длина описания товара")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }// Item Price

        [Range(1, 100,ErrorMessage = "Некоректное количество товаров!")]
        public int Quantity { get; set; }// quantity of items in the order

        public ItemCharacteristic ItemCharacteristic { get; set; }

        [Column("CategoryId")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Order> Orders { get; set; }
        public Item()
        {
            Orders = new List<Order>();
        }
    }
}
