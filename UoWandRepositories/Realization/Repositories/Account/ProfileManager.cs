using AutoMapper;
using Domain.Context;
using Domain.Entities.Account;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities.Account;
using UoWandRepositories.Interfaces.Account;

namespace UoWandRepositories.Realization.Repositories.Account
{
    public class ProfileManager : IProfileManager
    {
        public AccountDbContext Database { get; set; }

        public ProfileManager(AccountDbContext db)
        {
            Database = db;
        }

        public void Create(UserProfileUoW _profile)
        {

            UserProfile profile = new UserProfile()
            {
                Id = _profile.Id,
                Address = _profile.Address,
                Name = _profile.Name
            };
            Database.UserProfiles.Add(profile);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
