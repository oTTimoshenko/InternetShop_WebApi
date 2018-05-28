using Domain.Entities.Account;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Identity
{
    public class ShopRoleManager : RoleManager<ShopRole>
    {
        public ShopRoleManager(RoleStore<ShopRole> store)
                    : base(store)
        { }
    }
}
