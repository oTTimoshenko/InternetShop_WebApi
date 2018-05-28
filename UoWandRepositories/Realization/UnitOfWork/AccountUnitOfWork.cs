using AutoMapper;
using Domain.Context;
using Domain.Entities;
using Domain.Entities.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities.Account;
using UoWandRepositories.Identity;
using UoWandRepositories.Interfaces.Account;
using UoWandRepositories.Realization.Repositories.Account;

namespace UoWandRepositories.Realization.UnitOfWork
{
    public class AccountUnitOfWork : IAccountUnitOfWork
    {
        private AccountDbContext db;

        private ShopUserManager userManager;
        private ShopRoleManager roleManager;
        private IProfileManager profileManager;

        public AccountUnitOfWork(string connectionString)
        {
            db = new AccountDbContext(connectionString);
            userManager = new ShopUserManager(new UserStore<ShopUser>(db));
            roleManager = new ShopRoleManager(new RoleStore<ShopRole>(db));
            profileManager = new ProfileManager(db);
        }

        public ShopUserManager UserManager
        {
            get { return userManager; }
        }

        public IProfileManager ProfileManager
        {
            get { return profileManager; }
        }

        public ShopRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public OparationDetailsUoW Create(UserModelUoW userDto)
        {
            ShopUser user = UserManager.FindByEmail(userDto.Email);
            if (user == null)
            {
                user = new ShopUser { Email = userDto.Email, UserName = userDto.Email };
                var result = UserManager.Create(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OparationDetailsUoW(false, result.Errors.FirstOrDefault(), "");
                // добавляем роль
                UserManager.AddToRole(user.Id, userDto.Role);
                // создаем профиль клиента
                UserProfileUoW clientProfile = new UserProfileUoW { Id = user.Id, Address = userDto.Address, Name = userDto.Name };
                ProfileManager.Create(clientProfile);
                Save();
                return new OparationDetailsUoW(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OparationDetailsUoW(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public ClaimsIdentity Authenticate(UserModelUoW userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ShopUser user = UserManager.Find(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim =  UserManager.CreateIdentity(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public void SetInitialData(UserModelUoW adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = RoleManager.FindByName(roleName);
                if (role == null)
                {
                    role = new ShopRole { Name = roleName };
                    RoleManager.Create(role);
                }
            }
            Create(adminDto);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    profileManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
