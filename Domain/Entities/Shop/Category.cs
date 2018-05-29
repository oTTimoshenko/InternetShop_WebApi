using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Недопустимая длина названия категории")]
        public string CategoryName { get; set; }

        public ICollection<Item> Items { get; set; }

        public Category()
        {
            Items = new List<Item>();
        }
    }
}
