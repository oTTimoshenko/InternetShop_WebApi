using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
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

        public ItemCharacteristicsDTO GetItemCharacteristics(int Id)
        {
            return mapper.Map<ItemCharacteristicsDTO>(db.ItemCharacteristics.GetById(Id));
        }

        public ItemDTO GetItem(int Id)
        {
            return mapper.Map<ItemDTO>(db.Items.GetById(Id));
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

            return all_items.Where(item => item.ItemName.ToLower().Contains(request.ToLower()));
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

        public IEnumerable<ItemDTO> FilterByCategory(int categoryId)
        {
            var items = db.Items.GetAll().Where(item => item.CategoryId == categoryId);
            IEnumerable<ItemDTO> _items = mapper.Map<IEnumerable<ItemDTO>>(items);

            return _items;
        }

        private IEnumerable<ItemDTO> FilterByRAM(IEnumerable<ItemDTO> _items, int[] values)
        {
            List<ItemDTO> result = new List<ItemDTO>();

            foreach (var value in values)
            {
                var items = _items.Where(item => db.ItemCharacteristics.GetById(item.ItemId).RAM == value);
                result.AddRange(items);
            }

            return result;
        }

        private IEnumerable<ItemDTO> FilterByMemorySize(IEnumerable<ItemDTO> _items, int[] values)
        {

            List<ItemDTO> result = new List<ItemDTO>();

            foreach (var value in values)
            {
                var items = _items.Where(item => db.ItemCharacteristics.GetById(item.ItemId).Memory == value);
                result.AddRange(items);
            }

            return result;

        }

        private IEnumerable<ItemDTO> FilterByCamera(IEnumerable<ItemDTO> _items, double[] values)
        {
            List<ItemDTO> result = new List<ItemDTO>();

            foreach (var value in values)
            {
                var items = _items.Where(item => db.ItemCharacteristics.GetById(item.ItemId).Camera == value);
                result.AddRange(items);
            }

            return result;


        }

        private IEnumerable<ItemDTO> FilterByDisplayDiagonal(IEnumerable<ItemDTO> _items, double[] values)
        {
            List<ItemDTO> result = new List<ItemDTO>();

            foreach (var value in values)
            {
                var items = _items.Where(item => db.ItemCharacteristics.GetById(item.ItemId).DisplayDiagonal == value);
                result.AddRange(items);
            }

            return result;
        }

        private IEnumerable<ItemDTO> FilterByPrice(IEnumerable<ItemDTO> _items, int minPrice, int maxPrice)
        {
            return _items.Where(item => item.Price >= minPrice && item.Price <= maxPrice);
        }

        public IEnumerable<ItemDTO> FilterByCriteria(FilterCriteries filter)
        {
            IEnumerable<ItemDTO> result = new List<ItemDTO>();

            if (filter.RAM != null)
                result = FilterByRAM(GetAllItems(), filter.RAM);

            if (filter.MemorySize != null)
                result = FilterByMemorySize(result, filter.MemorySize);

            if (filter.Camera != null)
                result = FilterByCamera(result, filter.Camera);

            if (filter.DisplayDiagonal != null)
                result = FilterByDisplayDiagonal(result, filter.DisplayDiagonal);

            if(filter.minPrice == 0 || filter.minPrice == 0)
            {
                filter.minPrice = getDefaultMinPrice(result);
                filter.maxPrice = getDefaultMaxPrice(result);
            }

            result = FilterByPrice(result, filter.minPrice, filter.maxPrice);

            return result;
        }

        private int getDefaultMinPrice(IEnumerable<ItemDTO> _items)
        {
            return (int)_items.Min(x => x.Price);
        }

        private int getDefaultMaxPrice(IEnumerable<ItemDTO> _items)
        {
            return (int)_items.Max(x => x.Price);
        }
    }
}
