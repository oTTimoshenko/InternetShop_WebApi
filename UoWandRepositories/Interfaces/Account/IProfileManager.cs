using Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities.Account;

namespace UoWandRepositories.Interfaces.Account
{
    public interface IProfileManager : IDisposable
    {
        void Create(UserProfileUoW item);
    }
}
