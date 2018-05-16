using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers
{
    public class TestController : ApiController
    {
        IAdminService adminService;

        public TestController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public TestController()
        { }

        public void Post()
        {

        }
    }
}
