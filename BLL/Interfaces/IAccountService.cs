using BLL.Entity.Account;
using BLL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAccountService : IDisposable
    {
        OperationDetailsBLL Create(UserDTO userDto);
        ClaimsIdentity Authenticate(UserDTO userDto);
        void SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
