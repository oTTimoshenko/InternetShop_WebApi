using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class StatisticView
    {
        public ItemView hotItems { get; set; }
        public double totalItemsSold { get; set; }
        public double totalItems { get; set; }
        public double totalRevenue { get; set; }
    }
}