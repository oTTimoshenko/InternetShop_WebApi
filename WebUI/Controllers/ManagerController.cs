using AutoMapper;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
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
        [Route("api/ManagerPanel/acceptOrder")]
        public void ConfirmOrder(int id)
        {
            _manage.ConfirmOrder(id);
        }
        [HttpPut]
        [Route("api/ManagerPanel/declineOrder")]
        public void DeclineOrder(int id)
        {
            _manage.DeclineOrder(id);
        }

    }
}
