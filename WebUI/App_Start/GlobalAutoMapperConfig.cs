using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BLL.Infrastructure;
using UoWandRepositories.Infrastructure;

namespace WebUI.App_Start
{
    public static class GlobalAutoMapperConfig
    {
        public static void RegisterMap()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UoWMappingConfig());
                cfg.AddProfile(new BLLMappingConfig());
            });
        }
    }
}