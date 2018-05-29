using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class ItemView
    {
        public int ItemId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимая длина названия товара")]
        public string ItemName { get; set; }
        public string ItemPhotoPath { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 30, ErrorMessage = "Недопустимая длина описания товара")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Некоректное количество товаров!")]
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