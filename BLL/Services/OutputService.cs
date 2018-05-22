using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;

namespace BLL.Services
{
    public class OutputService : IOutputService
    {
        private readonly IShopUnitOfWork db;
        private readonly IMapper mapper;

        public OutputService(IShopUnitOfWork _db, IMapper mapper)
        {
            db = _db;
            this.mapper = mapper;
        }

        public IEnumerable<ItemDTO> GetAllItems()
        {
            return mapper.Map<IEnumerable<ItemDTO>>(db.Items.GetAll());
        }

        public IEnumerable<ItemDTO> GetItemsWithPagination(int page, int pageSize)
        {
            var itemsUoW = db.Items.GetAll()
                     .OrderBy(item => item.ItemId)
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize);

            return mapper.Map<IEnumerable<ItemDTO>>(itemsUoW);
        }

        public IEnumerable<ItemDTO> Search(string request)
        {
            var all_items = this.GetAllItems();

            return all_items.Where(item => item.ItemName.ToLower().Contains(request));
        }

        public IEnumerable<ItemDTO> SortBy(BLLSortCriteria sortParam)
        {
            IEnumerable<ItemDTO> all_items = GetAllItems();
            IEnumerable<ItemDTO> res;

            if (sortParam == BLLSortCriteria.NAME)
                res = all_items.OrderBy(x => x.ItemName);
            else
                res = all_items.OrderBy(x => x.Price);

            return res;
        }

        public IEnumerable<ItemDTO> SortByDescending(BLLSortCriteria sortParam)
        {
            IEnumerable<ItemDTO> all_items = GetAllItems();
            IEnumerable<ItemDTO> res;

            if (sortParam == BLLSortCriteria.NAME)
                res = all_items.OrderByDescending(x => x.ItemName);
            else
                res = all_items.OrderByDescending(x => x.Price);

            return res;
        }
    }
}
