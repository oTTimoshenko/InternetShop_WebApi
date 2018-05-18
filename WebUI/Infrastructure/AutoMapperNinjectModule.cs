using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using AutoMapper;
using BLL.Infrastructure;
using UoWandRepositories.Infrastructure;

namespace WebUI.Infrastructure
{
    public class AutoMapperNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();
        }

        private IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(config =>
            {
                config.ConstructServicesUsing(type => context.Kernel.GetType());

                config.AddProfile(new BLLMappingConfig());
                config.AddProfile(new UoWMappingConfig());
                config.AddProfile(new WebApiMappingConfig());
                // .... other mappings, Profiles, etc.              

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}