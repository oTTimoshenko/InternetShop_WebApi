using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ItemsListViewModel
    {
        public IEnumerable<ItemView> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}