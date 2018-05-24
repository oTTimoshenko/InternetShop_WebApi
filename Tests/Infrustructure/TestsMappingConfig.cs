using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using UoWandRepositories.Entities;

namespace Tests.Infrustructure
{
    public class TestsMappingConfig:Profile
    {
        public TestsMappingConfig()
        {
            CreateMap<CategoryDTO, CategoryUoW>().ReverseMap().MaxDepth(2);
            CreateMap<ItemDTO, ItemUoW>().ReverseMap().MaxDepth(2);
            CreateMap<ItemCharacteristicsDTO, ItemCharacteristicUoW>().ReverseMap().MaxDepth(2);
            CreateMap<OrderDTO, OrderUoW>().ReverseMap().MaxDepth(2);
            CreateMap<StateDTO, StateUoW>().ReverseMap();
        }
    }
}
