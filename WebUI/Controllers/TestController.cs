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
        //IMapper mapper;
        

        public TestController(IAdminService _adminService)
        {
            adminService = _adminService;
           // this.mapper = mapper;
        }

        public TestController()
        { }

        public void PostCategory(string name)
        {
            CategoryDTO category = new CategoryDTO() { CategoryName = name, Items = null };
            //var _category = mapper.Map<CategoryDTO>(category);
            adminService.AddCategory(category);
        }

        public CategoryView GetCategory(int id)
        {
            var category = adminService.GetCategory(id);
            CategoryView res = new CategoryView() { CategoryName = category.CategoryName, Items = null };
            //CategoryView _category = mapper.Map<CategoryView>(category);
            return res;
        }
    }
}
