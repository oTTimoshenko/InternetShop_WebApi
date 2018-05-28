using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Realization.UnitOfWork;

namespace BLL.Services
{
    public class AccountServiceCreator : IAccountServiceCreator
    {
        public IAccountService CreateAccountService(string connection)
        {
            return new AccountService(new AccountUnitOfWork(connection));
        }
    }
}
