using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OutputController : ApiController
    {
        IOutputService outputService;
        IMapper mapper;

        public OutputController(IOutputService _outputService, IMapper mapper)
        {
            outputService = _outputService;
            this.mapper = mapper;
        }
        public OutputController()
        { }

        [HttpGet]
        [Route("api/output/items/get/{id}")]
        public ItemView GetItem(int id)
        {
            var item = outputService.GetItem(id);
            ItemView _item = mapper.Map<ItemView>(item);
            return _item;
        }

        [HttpGet]
        [Route("api/output/characteristics/get/{id}")]
        public ItemCharacteristicView GetItemCharacteristic(int id)
        {
            var itemCharacteristic = outputService.GetItemCharacteristics(id);
            ItemCharacteristicView _itemCharacteristic = mapper.Map<ItemCharacteristicView>(itemCharacteristic);
            return _itemCharacteristic;
        }

        [HttpGet]
        [Route("api/output/pagination")]
        public ItemsListViewModel PagingItemsList([FromUri]PaginationParams parametrs)
        {
            int page = parametrs.CurrentPage;
            int pageSize = parametrs.PageSize;

            var items = outputService.GetItemsWithPagination(page, pageSize);

            ItemsListViewModel model = new ItemsListViewModel()
            {
                Items = mapper.Map<IEnumerable<ItemView>>(items),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = outputService.GetAllItems().Count()
                }
            };

            return model;
        }

        [HttpGet]
        [Route("api/output/all_items")]
        public IEnumerable<ItemView> GetAllItems()
        {
            var items = outputService.GetAllItems();
            return mapper.Map<IEnumerable<ItemView>>(items);
        }

        [HttpGet]
        [Route("api/output/search")]
        public IEnumerable<ItemView> Search([FromUri]string request)
        {
            var searchItems = outputService.Search(request);

            return mapper.Map<IEnumerable<ItemView>>(searchItems);
        }

        [HttpGet]
        [Route("api/output/sort_by/{sortCriteria}")]
        public IEnumerable<ItemView> SortBy(SortCriteriaView sortCriteria = SortCriteriaView.NAME)
        {
            var criteria = mapper.Map<BLLSortCriteria>(sortCriteria);
            var sorted_items = mapper.Map<IEnumerable<ItemView>>(outputService.SortBy(criteria));

            return sorted_items;
        }

        [HttpGet]
        [Route("api/output/sort_by_descending/{sortCriteria}")]
        public IEnumerable<ItemView> SortByDescending(SortCriteriaView sortCriteria = SortCriteriaView.NAME)
        {
            var criteria = mapper.Map<BLLSortCriteria>(sortCriteria);
            var sorted_items = mapper.Map<IEnumerable<ItemView>>(outputService.SortByDescending(criteria));

            return sorted_items;
        }

        [HttpGet]
        [Route("api/output/filter_by_criteries")]
        public IEnumerable<ItemView> FilterByCriteries([FromUri]WebApiFilterCriteries criteries)
        {
            var _criteries = mapper.Map<FilterCriteries>(criteries);

            var items = outputService.FilterByCriteria(_criteries);
            var filter_items = mapper.Map<IEnumerable<ItemView>>(items);

            return filter_items;
        }

        [HttpGet]
        [Route("api/output/filter_by_category/{id}")]
        public IEnumerable<ItemView> FilterByCategory(int id)
        {
            var items = outputService.FilterByCategory(id);
            var filter_items = mapper.Map<IEnumerable<ItemView>>(items);

            return filter_items;
        }
    }
}
