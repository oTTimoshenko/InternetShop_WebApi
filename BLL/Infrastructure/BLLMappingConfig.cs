using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Entity.Account;
using UoWandRepositories.Entities;
using UoWandRepositories.Entities.Account;

namespace BLL.Infrastructure
{
    public class BLLMappingConfig:Profile
    {
        public BLLMappingConfig()
        {
            CreateMap<CategoryDTO, CategoryUoW>().ReverseMap().MaxDepth(2);
            CreateMap<ItemDTO, ItemUoW>().ReverseMap().MaxDepth(2);
            CreateMap<ItemCharacteristicsDTO, ItemCharacteristicUoW>().ReverseMap().MaxDepth(2);
            CreateMap<OrderDTO, OrderUoW>().ReverseMap().MaxDepth(2);
            CreateMap<StateDTO, StateUoW>().ReverseMap();
            CreateMap<UserDTO, UserModelUoW>().ReverseMap();
        }
    }
}
