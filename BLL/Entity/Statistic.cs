using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Statistic
    {
        public ItemDTO hotItems { get; set; }
        public double totalItemsSold { get; set; }
        public double totalItems { get; set; }
        public double totalRevenue { get; set; }
    }
}
