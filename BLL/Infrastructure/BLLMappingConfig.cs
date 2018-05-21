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
            CreateMap<CategoryDTO, CategoryUoW>().ReverseMap().MaxDepth(5);
            CreateMap<ItemDTO, ItemUoW>().ReverseMap().MaxDepth(5);
            CreateMap<ItemCharacteristicsDTO, ItemCharacteristicUoW>().ReverseMap().MaxDepth(5);
            CreateMap<OrderDTO, OrderUoW>().ReverseMap().MaxDepth(5);
            CreateMap<StateDTO, StateUoW>().ReverseMap();
        }
    }
}
