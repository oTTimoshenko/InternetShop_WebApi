using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using UoWandRepositories.Infrastructure;
using WebUI.Infrastructure;
using WebUI.Models;

namespace WebUI.App_Start
{
    public static class GlobalAutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UoWMappingConfig());
                cfg.AddProfile(new BLLMappingConfig());
                cfg.AddProfile(new WebApiMappingConfig());
            });
        }
    }
}