using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Account;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Entities
{
    public class ShopUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; }
    }
}
