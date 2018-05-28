using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;

namespace WebUI.Controllers
{

    public class AdminController : ApiController
    {
        IAdminService adminService;
        IMapper mapper;


        public AdminController(IAdminService _adminService, IMapper mapper)
        {
            adminService = _adminService;
            this.mapper = mapper;
        }
        public AdminController()
        { }

        [HttpPost]
        [Route("api/adminPanel/categories/add")]
        public void AddCategory([FromBody]CategoryView category)
        {
            var _category = mapper.Map<CategoryDTO>(category);
            adminService.AddCategory(_category);
        }

        [HttpPut]
        [Route("api/adminPanel/categories/edit")]
        public void UpdateCategory([FromBody]CategoryView category)
        {
            var _category = mapper.Map<CategoryDTO>(category);
            adminService.UpdateCategory(_category);
        }

        [HttpDelete]
        [Route("api/adminPanel/categories/delete/{id}")]
        public void DeleteCategory(int id)
        {
            adminService.RemoveCategory(id);
        }

        [HttpGet]
        [Route("api/adminPanel/categories/get/{id}")]
        [Authorize(Roles = "admin")]
        public CategoryView GetCategory(int id)
        {
            var category = adminService.GetCategory(id);
            CategoryView _category = mapper.Map<CategoryView>(category);
            return _category;
        }



        [HttpPost]
        [Route("api/adminPanel/items/add")]
        public void AddItem([FromBody]ItemView itemView)
        {
            var _item = mapper.Map<ItemDTO>(itemView);
            adminService.AddItem(_item);
        }

        [HttpPut]
        [Route("api/adminPanel/items/edit")]
        public void UpdateItem([FromBody]ItemView item)
        {
            var _item = mapper.Map<ItemDTO>(item);
            adminService.UpdateItem(_item);
        }
    
        [HttpDelete]
        [Route("api/adminPanel/items/delete/{id}")]
        public void DeleteItem(int id)
        {
            adminService.RemoveItem(id);
        }

        [HttpGet]
        [Route("api/adminPanel/items/get/{id}")]
        public ItemView GetItem(int id)
        {
            var item = adminService.GetItem(id);
            ItemView _item = mapper.Map<ItemView>(item);
            return _item;
        }




        [HttpPost]
        [Route("api/adminPanel/characteristics/add")]
        public void AddItemCharacteristic([FromBody]ItemCharacteristicView itemCharacteristic)
        {
            var _itemCharacteristic = mapper.Map<ItemCharacteristicsDTO>(itemCharacteristic);
            adminService.AddItemCharacteristic(_itemCharacteristic);
        }

        [HttpPut]
        [Route("api/adminPanel/characteristics/edit")]
        public void UpdateItemCharacteristic([FromBody]ItemCharacteristicView itemCharacteristic)
        {
            var _itemCharacteristic = mapper.Map<ItemCharacteristicsDTO>(itemCharacteristic);
            adminService.UpdateItemCharacteristic(_itemCharacteristic);
        }

        [HttpDelete]
        [Route("api/adminPanel/characteristics/delete/{id}")]
        public void DeleteItemCharacteristic(int id)
        {
            adminService.RemoveItemCharacteristic(id);
        }

        [HttpGet]
        [Route("api/adminPanel/characteristics/get/{id}")]
        public ItemCharacteristicView GetItemCharacteristic(int id)
        {
            var itemCharacteristic = adminService.GetItemCharacteristics(id);
            ItemCharacteristicView _itemCharacteristic = mapper.Map<ItemCharacteristicView>(itemCharacteristic);
            return _itemCharacteristic;
        }
    }
}
