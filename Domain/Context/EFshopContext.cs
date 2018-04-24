using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;

namespace Domain.Context
{
    public class EFshopContext:DbContext
    {
        public EFshopContext(string connectionString)
            :base(connectionString)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemCharacteristic> ItemCharacteristics { get; set; }
    }
}
