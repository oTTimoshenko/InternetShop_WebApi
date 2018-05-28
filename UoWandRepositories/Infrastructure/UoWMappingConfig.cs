using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Account;
using UoWandRepositories.Entities;
using UoWandRepositories.Entities.Account;

namespace UoWandRepositories.Infrastructure
{
    public class UoWMappingConfig : Profile
    {
        public UoWMappingConfig()
        {
            CreateMap<ItemCharacteristic, ItemCharacteristicUoW>().ReverseMap().MaxDepth(2);
            CreateMap<Category, CategoryUoW>().ReverseMap().MaxDepth(2);
            CreateMap<Item, ItemUoW>().ReverseMap().MaxDepth(2);
            CreateMap<Order, OrderUoW>().ReverseMap().MaxDepth(2);
            CreateMap<State, StateUoW>().ReverseMap();

            CreateMap<ShopUser, UserUoW>().ReverseMap().MaxDepth(2);
            CreateMap<ShopRole, RoleUoW>().ReverseMap().MaxDepth(2);
            CreateMap<UserProfile, UserProfileUoW>().ReverseMap().MaxDepth(2);
        }
    }
}
