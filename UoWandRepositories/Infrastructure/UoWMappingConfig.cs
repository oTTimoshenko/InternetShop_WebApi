using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using UoWandRepositories.Entities;

namespace UoWandRepositories.Infrastructure
{
    public class UoWMappingConfig : Profile
    {
        public UoWMappingConfig()
        {
            CreateMap<ItemCharacteristic, ItemCharacteristicUoW>().ReverseMap().MaxDepth(5);
            CreateMap<Category, CategoryUoW>().ReverseMap().MaxDepth(5);
            CreateMap<Item, ItemUoW>().ReverseMap().MaxDepth(5);
            CreateMap<Order, OrderUoW>().ReverseMap().MaxDepth(5);          
        }
    }
}
