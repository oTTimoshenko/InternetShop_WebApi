using BLL.DTO;
using BLL.Models;
using System.Collections.Generic;
namespace BLL.Interfaces
{
    public interface IOutputService
    {
        ItemCharacteristicsDTO GetItemCharacteristics(int Id);
        ItemDTO GetItem(int Id);

        IEnumerable<ItemDTO> GetAllItems();
        IEnumerable<ItemDTO> GetItemsWithPagination(int page, int pageSize);
        IEnumerable<ItemDTO> SortBy(BLLSortCriteria sortParam);
        IEnumerable<ItemDTO> SortByDescending(BLLSortCriteria sortParam);
        IEnumerable<ItemDTO> Search(string request);
        IEnumerable<ItemDTO> FilterByCategory(int categoryId);
        IEnumerable<ItemDTO> FilterByCriteria(FilterCriteries filter);
    }
}
