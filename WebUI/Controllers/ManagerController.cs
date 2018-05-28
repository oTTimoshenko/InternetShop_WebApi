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
        public void UpdateOrder([FromBody]OrderView order)
        {
            var _order = _mapper.Map<OrderDTO>(order);
            _manage.UpdateOrder(_order);
        }

        [HttpGet]
        [Route("api/ManagerPanel/orders/get/{id}")]
        public OrderView GetOrder(int id)
        {
            var order = _manage.GetOrder(id);
            OrderView _order = _mapper.Map<OrderView>(order);
            return _order;
        }
    }
}
