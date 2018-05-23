using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Entity;
using BLL.Interfaces;
using WebUI.Models;

namespace WebUI.Infrastructure
{
    public class WebApiMappingConfig:Profile
    {
        public WebApiMappingConfig()
        {
            CreateMap<CategoryView, CategoryDTO>().ReverseMap().MaxDepth(5);
            CreateMap<ItemView, ItemDTO>().ReverseMap().MaxDepth(5);
            CreateMap<ItemCharacteristicView, ItemCharacteristicsDTO>().ReverseMap().MaxDepth(5);
            CreateMap<OrderView, OrderDTO>().ReverseMap().MaxDepth(5);
            CreateMap<StateView, StateDTO>().ReverseMap();
            //CreateMap<ShoppingCartView, ShoppingCart>().ReverseMap();
            //CreateMap<ShoppingCartLineView, ShoppingCartLine>().ReverseMap();
          //  CreateMap<ShoppingCartView, ShoppingCart>().ReverseMap();
        }
    }
}