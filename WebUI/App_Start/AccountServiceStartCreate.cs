using AutoMapper;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.App_Start
{
    public class AccountServiceStartCreate
    {
        IAccountService accountService;
        IMapper mapper;
        public AccountServiceStartCreate(IAccountService service, IMapper mapper)
        {
            accountService = service;
            this.mapper = mapper;
        }

        public IAccountService GetAccountService()
        {
            return accountService;
        }
    }
}