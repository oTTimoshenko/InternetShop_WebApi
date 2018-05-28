using AutoMapper;
using BLL.Entity.Account;
using BLL.Infrastructure;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities.Account;
using UoWandRepositories.Interfaces.Account;

namespace BLL.Services
{
    public class AccountService:IAccountService
    {
        IAccountUnitOfWork Database { get; set; }

        public AccountService(IAccountUnitOfWork uow)
        {
            Database = uow;
        }

        public OperationDetailsBLL Create(UserDTO userDto)
        {
            UserModelUoW userUoW = new UserModelUoW()
            {
                Email = userDto.Email,
                Password = userDto.Password,
                UserName = userDto.UserName,
                Name = userDto.Name,
                Address = userDto.Address,
                Role = userDto.Role
            };
            OparationDetailsUoW oparationDetailsUoW =  Database.Create(userUoW);
            OperationDetailsBLL operationDetailsBLL = new OperationDetailsBLL(oparationDetailsUoW.Succedeed,
                oparationDetailsUoW.Message, oparationDetailsUoW.Property);

            return operationDetailsBLL;
        }
        public ClaimsIdentity Authenticate(UserDTO userDto)
        {
            UserModelUoW userUoW = new UserModelUoW()
            {
                Email = userDto.Email,
                Password = userDto.Password,
                UserName = userDto.UserName,
                Name = userDto.Name,
                Address = userDto.Address,
                Role = userDto.Role
            };
            return Database.Authenticate(userUoW);
        }
        public void SetInitialData(UserDTO adminDto, List<string> roles)
        {
            UserModelUoW admin = new UserModelUoW()
            {
                Email = adminDto.Email,
                Password = adminDto.Password,
                UserName = adminDto.UserName,
                Name = adminDto.Name,
                Address = adminDto.Address,
                Role = adminDto.Role
            };
            Database.SetInitialData(admin, roles);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
