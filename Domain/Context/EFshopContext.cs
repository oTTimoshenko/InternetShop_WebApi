using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Entities;
using Domain.Interfaces;

namespace Domain.Context
{
    public class EFshopContext:DbContext, IEFshopContext
    {
        static EFshopContext()
        {
            Database.SetInitializer<EFshopContext>(new DropCreateDatabaseIfModelChanges<EFshopContext>());
        }
        
        public EFshopContext(string connectionString)
            :base(connectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
            .HasMany(p => p.Items)
            .WithMany(c => c.Orders)
            .Map(m =>
            {
             m.ToTable("ItemOrders");
             m.MapLeftKey("OrderId");
             m.MapRightKey("ItemId");
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemCharacteristic> ItemCharacteristics { get; set; }
    }

    
}
