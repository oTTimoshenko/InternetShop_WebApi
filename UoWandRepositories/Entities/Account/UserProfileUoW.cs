using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities.Account
{
    public class UserProfileUoW
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public UserUoW ShopUser { get; set; }
    }
}
