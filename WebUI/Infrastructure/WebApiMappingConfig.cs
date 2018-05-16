using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using WebUI.Models;

namespace WebUI.Infrastructure
{
    public class WebApiMappingConfig:Profile
    {
        public WebApiMappingConfig()
        {
            CreateMap<CategoryView, CategoryDTO>().ReverseMap();
            CreateMap<ItemView, ItemDTO>().ReverseMap();
            CreateMap<ItemCharacteristicView, ItemCharacteristicsDTO>().ReverseMap();
            CreateMap<OrderView, OrderDTO>().ReverseMap();
        }
    }
}