using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Authorize(Roles = "manager")]
    public class ManagerController : ApiController
    {
        IManageService _manage;
        IMapper _mapper;

        public ManagerController(IManageService manage, IMapper mapper)
        {
            _manage = manage;
            _mapper = mapper;
        }
        public ManagerController() { }

        [HttpPut]
        [Route("api/ManagerPanel/orders/edit")]
        public IHttpActionResult UpdateOrder([FromBody]OrderView order)
        {
            if (ModelState.IsValid)
            {
                var _order = _mapper.Map<OrderDTO>(order);
                bool result = _manage.UpdateOrder(_order);

                if (result)
                    return Ok();
            }
            else
                return BadRequest(ModelState);

            return BadRequest();
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/get/{id}")]
        public IHttpActionResult GetOrder(int id)
        {
            var order = _manage.GetOrder(id);
            if (order != null)
            {
                OrderView _order = _mapper.Map<OrderView>(order);
                return Ok(_order);
            }
            return NotFound();
        }
    }
}
