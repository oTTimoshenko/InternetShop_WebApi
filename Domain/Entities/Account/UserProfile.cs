using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Account
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ShopUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ShopUser ShopUser { get; set; }
    }
}
