using BLL.DTO;
using BLL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStatisticService
    {
        IEnumerable<OrderDTO> getAllOrders();
        Statistic getOverallStats();
        IEnumerable<ItemDTO> getAllItems();
    }
}
