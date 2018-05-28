using Domain.Entities;
using Domain.Entities.Account;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class AccountDbContext : IdentityDbContext<ShopUser>
    {
        public AccountDbContext(string conectionString) : base(conectionString) { }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
