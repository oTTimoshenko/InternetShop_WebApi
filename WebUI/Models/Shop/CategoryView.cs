using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class CategoryView
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ItemView> Items { get; set; }

        public CategoryView()
        {
            Items = new List<ItemView>();
        }
    }
}