using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class CategoryView
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимая длина названия категории")]
        public string CategoryName { get; set; }

        public ICollection<ItemView> Items { get; set; }

        public CategoryView()
        {
            Items = new List<ItemView>();
        }
    }
}