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
            CreateMap<CategoryView, CategoryDTO>().ReverseMap().MaxDepth(2);  
            CreateMap<ItemView, ItemDTO>().ReverseMap().MaxDepth(2);
            CreateMap<ItemCharacteristicView, ItemCharacteristicsDTO>().ReverseMap().MaxDepth(2);
            CreateMap<OrderView, OrderDTO>().ReverseMap().MaxDepth(2);
            CreateMap<StateView, StateDTO>().ReverseMap();
            CreateMap<SortCriteriaView, BLLSortCriteria>().ReverseMap();
        }
    }
}