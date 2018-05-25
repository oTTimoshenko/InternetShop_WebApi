using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Entity;
using BLL.Interfaces;
using BLL.Models;
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

            CreateMap<FilterCriteries, WebApiFilterCriteries>().ReverseMap();

            CreateMap<StateView, StateDTO>().ReverseMap();
            CreateMap<StatisticView, Statistic>().ReverseMap();
        }
    }
}