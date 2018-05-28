using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


[assembly: OwinStartup(typeof(WebUI.App_Start.Startup))]


namespace WebUI.App_Start
{
    public class Startup
    {
        IAccountServiceCreator serviceCreator = new AccountServiceCreator();
       
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IAccountService>(CreateAccountService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IAccountService CreateAccountService()
        {
            return serviceCreator.CreateAccountService("AccountConnection");
        }
    }
}