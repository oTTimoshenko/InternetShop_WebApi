using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Entity;
using BLL.Interfaces;
using BLL.Services;
using Ninject.Modules;

namespace WebUI.Infrastructure
{
    public class WebApiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IShoppingCart>().To<ShoppingCart>().InSingletonScope();
        }


    }
}