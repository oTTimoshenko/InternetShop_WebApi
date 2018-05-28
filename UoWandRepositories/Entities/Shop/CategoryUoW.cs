using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities
{
    public class CategoryUoW
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ItemUoW> Items { get; set; }

        public CategoryUoW()
        {
            Items = new List<ItemUoW>();
        }
    }
}
