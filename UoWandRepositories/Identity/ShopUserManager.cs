using Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Identity
{
    public class ShopUserManager : UserManager<ShopUser>
    {
        public ShopUserManager(IUserStore<ShopUser> store)
                : base(store)
        {
        }
    }
}
