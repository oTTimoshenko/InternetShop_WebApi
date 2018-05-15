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
    public static class UoWMappingConfigModule
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ItemCharacteristic, ItemCharacteristicUoW>().ReverseMap();

                cfg.CreateMap<Category, CategoryUoW>().ReverseMap();

                cfg.CreateMap<Item, ItemUoW>().ReverseMap();
                cfg.CreateMap<Order, OrderUoW>().ReverseMap();
            }
            );
        }
    }
}
