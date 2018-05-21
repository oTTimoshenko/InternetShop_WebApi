using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Models;
using AutoMapper;
using BLL.DTO;

namespace WebUI.Controllers
{
    public class TestController : ApiController
    {
        IAdminService adminService;
        IMapper mapper;
        

        public TestController(IAdminService _adminService, IMapper mapper)
        {
            adminService = _adminService;
            this.mapper = mapper;
        }

        public TestController()
        { }

        [HttpPost]
        public void PostCategory(string name)
        {
            CategoryView category = new CategoryView() { CategoryName = name};
            //CategoryDTO _category = new CategoryDTO() { CategoryName = name }; 
            var _category = mapper.Map<CategoryDTO>(category);
            adminService.AddCategory(_category);
        }

        [HttpGet]
        public CategoryView GetCategory(int id)
        {
            var category1 = adminService.GetCategory(id);
            //CategoryView res = new CategoryView() { CategoryName = category.CategoryName, Items = null };
            CategoryView _category1 = mapper.Map<CategoryView>(category1);
            return _category1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                adminService.Dispose(disposing);
            }
            base.Dispose(disposing);
        }
    }
}
