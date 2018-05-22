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
        IEnumerable<ItemDTO> GetItemsWithPagination(int page, int pageSize);
        IEnumerable<ItemDTO> SortBy(BLLSortCriteria sortParam);
        IEnumerable<ItemDTO> SortByDescending(BLLSortCriteria sortParam);
        IEnumerable<ItemDTO> Search(string request);
    }
}
