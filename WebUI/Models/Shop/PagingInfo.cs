using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PagingInfo
    {
        
        public int TotalItems { get; set; } //Count of Items

        public int ItemsPerPage { get; set; } //Count of items on one page

        public int CurrentPage { get; set; } // number of current page

        public int TotalPages //Count of all pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}