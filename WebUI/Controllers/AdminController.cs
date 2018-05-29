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
    [Authorize(Roles = "admin")]
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
        public IHttpActionResult AddCategory([FromBody]CategoryView category)
        {
            if (ModelState.IsValid)
            {
                var _category = mapper.Map<CategoryDTO>(category);
                bool result = adminService.AddCategory(_category);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpPut]
        [Route("api/adminPanel/categories/edit")]
        public IHttpActionResult UpdateCategory([FromBody]CategoryView category)
        {
            if (ModelState.IsValid)
            {
                var _category = mapper.Map<CategoryDTO>(category);
                bool result = adminService.UpdateCategory(_category);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/adminPanel/categories/delete/{id}")]
        public IHttpActionResult DeleteCategory(int id)
        {
            bool result = adminService.RemoveCategory(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        [Route("api/adminPanel/categories/get/{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            var category = adminService.GetCategory(id);

            if (category != null)
            {
                CategoryView _category = mapper.Map<CategoryView>(category);
                return Ok(_category);
            }

            return NotFound();
        }



        [HttpPost]
        [Route("api/adminPanel/items/add")]
        public IHttpActionResult AddItem([FromBody]ItemView itemView)
        {
            if (ModelState.IsValid)
            {
                var _item = mapper.Map<ItemDTO>(itemView);
                bool result = adminService.AddItem(_item);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpPut]
        [Route("api/adminPanel/items/edit")]
        [Authorize(Roles = "manager")]
        public IHttpActionResult UpdateItem([FromBody]ItemView item)
        {
            if (ModelState.IsValid)
            {
                var _item = mapper.Map<ItemDTO>(item);
                bool result = adminService.UpdateItem(_item);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/adminPanel/items/delete/{id}")]
        public IHttpActionResult DeleteItem(int id)
        {
            bool result = adminService.RemoveItem(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        [Route("api/adminPanel/items/get/{id}")]
        public IHttpActionResult GetItem(int id)
        {
            var item = adminService.GetItem(id);

            if (item != null)
            {
                ItemView _item = mapper.Map<ItemView>(item);
                return Ok(_item);
            }

            return NotFound();
        }



        [HttpPost]
        [Route("api/adminPanel/characteristics/add")]
        public IHttpActionResult AddItemCharacteristic([FromBody]ItemCharacteristicView itemCharacteristic)
        {
            if (ModelState.IsValid)
            {
                var _itemCharacteristic = mapper.Map<ItemCharacteristicsDTO>(itemCharacteristic);
                bool result = adminService.AddItemCharacteristic(_itemCharacteristic);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpPut]
        [Route("api/adminPanel/characteristics/edit")]
        public IHttpActionResult UpdateItemCharacteristic([FromBody]ItemCharacteristicView itemCharacteristic)
        {
            if (ModelState.IsValid)
            {
                var _itemCharacteristic = mapper.Map<ItemCharacteristicsDTO>(itemCharacteristic);
                bool result = adminService.UpdateItemCharacteristic(_itemCharacteristic);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpDelete]
        [Route("api/adminPanel/characteristics/delete/{id}")]
        public IHttpActionResult DeleteItemCharacteristic(int id)
        {
            bool result = adminService.RemoveItemCharacteristic(id);

            if (result)
                return Ok();

            return BadRequest();
        }

        [HttpGet]
        [Route("api/adminPanel/characteristics/get/{id}")]
        public IHttpActionResult GetItemCharacteristic(int id)
        {
            var itemCharacteristic = adminService.GetItemCharacteristics(id);
            if (itemCharacteristic != null)
            {
                ItemCharacteristicView _itemCharacteristic = mapper.Map<ItemCharacteristicView>(itemCharacteristic);
                return Ok(_itemCharacteristic);
            }

            return NotFound();
        }
    }
}
