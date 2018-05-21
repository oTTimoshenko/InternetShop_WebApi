using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOutputService
    {
        IEnumerable<ItemDTO> GetAllItems();
        void Sort();
        ItemDTO Search();
    }
}
