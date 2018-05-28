using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities.Account;
using UoWandRepositories.Identity;

namespace UoWandRepositories.Interfaces.Account
{
    public interface IAccountUnitOfWork : IDisposable
    {
        ShopUserManager UserManager { get; }
        IProfileManager ProfileManager { get; }
        ShopRoleManager RoleManager { get; }

        OparationDetailsUoW Create(UserModelUoW userDto);
        ClaimsIdentity Authenticate(UserModelUoW userDto);
        void SetInitialData(UserModelUoW adminDto, List<string> roles);
        void Save();
    }
}
