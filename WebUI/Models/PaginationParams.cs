using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class PaginationParams
    {
        public int CurrentPage { get; set; } 
        public int PageSize { get; set; }
    }
}