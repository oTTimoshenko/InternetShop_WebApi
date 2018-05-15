using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using UoWandRepositories.Entities;

namespace BLL.Infrastructure
{
    public class BLLMappingConfig:Profile
    {
        public BLLMappingConfig()
        {
            CreateMap<CategoryDTO, CategoryUoW>().ReverseMap();
            CreateMap<ItemDTO, ItemUoW>().ReverseMap();
            CreateMap<ItemCharacteristicsDTO, ItemCharacteristicUoW>().ReverseMap();
            CreateMap<OrderDTO, OrderUoW>().ReverseMap();
        }
    }
}
