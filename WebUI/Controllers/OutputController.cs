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
        public IHttpActionResult GetItem(int id)
        {
            var item = outputService.GetItem(id);
            if (item != null)
            {
                ItemView _item = mapper.Map<ItemView>(item);
                return Ok(_item);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/output/characteristics/get/{id}")]
        public IHttpActionResult GetItemCharacteristic(int id)
        {
            var itemCharacteristic = outputService.GetItemCharacteristics(id);
            if (itemCharacteristic != null)
            {
                ItemCharacteristicView _itemCharacteristic = mapper.Map<ItemCharacteristicView>(itemCharacteristic);
                return Ok(_itemCharacteristic);
            }

            return NotFound();
        }

        [HttpGet]
        [Route("api/output/pagination")]
        public IHttpActionResult PagingItemsList([FromUri]PaginationParams parametrs)
        {
            if (ModelState.IsValid)
            {
                int page = parametrs.CurrentPage;
                int pageSize = parametrs.PageSize;

                var items = outputService.GetItemsWithPagination(page, pageSize);

                if (items.Count() == 0)
                    return NotFound();

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

                return Ok(model);
            }

            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("api/output/all_items")]
        public IHttpActionResult GetAllItems()
        {
            var items = outputService.GetAllItems();

            if (items.Count() == 0)
                return NotFound();

            var _items = mapper.Map<IEnumerable<ItemView>>(items);

            return Ok(_items);
        }

        [HttpGet]
        [Route("api/output/search")]
        public IHttpActionResult Search([FromUri]string request)
        {
            var searchItems = outputService.Search(request);

            if (searchItems.Count() == 0)
                return NotFound();

            var _searchItems = mapper.Map<IEnumerable<ItemView>>(searchItems);

            return Ok(_searchItems);
        }

        [HttpGet]
        [Route("api/output/sort_by/{sortCriteria}")]
        public IHttpActionResult SortBy(SortCriteriaView sortCriteria = SortCriteriaView.NAME)
        {
            var criteria = mapper.Map<BLLSortCriteria>(sortCriteria);
            var sorted_items = mapper.Map<IEnumerable<ItemView>>(outputService.SortBy(criteria));

            if (sorted_items.Count() == 0)
                return BadRequest();

            return Ok(sorted_items);
        }

        [HttpGet]
        [Route("api/output/sort_by_descending/{sortCriteria}")]
        public IHttpActionResult SortByDescending(SortCriteriaView sortCriteria = SortCriteriaView.NAME)
        {
            var criteria = mapper.Map<BLLSortCriteria>(sortCriteria);
            var sorted_items = mapper.Map<IEnumerable<ItemView>>(outputService.SortByDescending(criteria));

            if (sorted_items.Count() == 0)
                return BadRequest();

            return Ok(sorted_items);
        }

        [HttpGet]
        [Route("api/output/filter_by_criteries")]
        public IHttpActionResult FilterByCriteries([FromUri]WebApiFilterCriteries criteries)
        {
            var _criteries = mapper.Map<FilterCriteries>(criteries);

            var items = outputService.FilterByCriteria(_criteries);
            var filter_items = mapper.Map<IEnumerable<ItemView>>(items);

            if (filter_items.Count() == 0)
                return BadRequest();

            return Ok(filter_items);
        }

        [HttpGet]
        [Route("api/output/filter_by_category/{id}")]
        public IHttpActionResult FilterByCategory(int id)
        {
            var items = outputService.FilterByCategory(id);
            var filter_items = mapper.Map<IEnumerable<ItemView>>(items);

            if (filter_items.Count() == 0)
                return BadRequest();

            return Ok(filter_items);
        }
    }
}
