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
            CreateMap<ItemCharacteristic, ItemCharacteristicUoW>().ReverseMap();
            CreateMap<Category, CategoryUoW>().ReverseMap();
            CreateMap<Item, ItemUoW>().ReverseMap();
            CreateMap<Order, OrderUoW>().ReverseMap();          
        }
    }
}
