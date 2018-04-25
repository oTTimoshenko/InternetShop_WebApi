using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;

namespace UoWandRepositories.UnitOfWork
{
    public class ShopUnitOfWork : IShopUnitOfWork
    {
        private DbContext _dbContext;
        private ICategoryRepository categoryRepository;
        private IItemCharacteristicRepository itemCharacteristicRepository;
        private IItemRepository itemRepository;
        private IOrderRepository orderRepository;

        public ShopUnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public IShopGenericRepository<Category> Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_dbContext);
                return categoryRepository;
            }
        }

        public IShopGenericRepository<ItemCharacteristic> ItemCharacteristics
        {
            get
            {
                if (itemCharacteristicRepository == null)
                    itemCharacteristicRepository = new ItemCharacteristicRepository(_dbContext);
                return itemCharacteristicRepository;
            }
        }

        public IShopGenericRepository<Item> Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(_dbContext);
                return itemRepository;
            }
        }

        public IShopGenericRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_dbContext);
                return orderRepository;
            }
        }

        public int Commit()// Save changes
        {

            return _dbContext.SaveChanges();
        }

        // Disposes the current object
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        // Disposes all external resources.
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                {
                    if (_dbContext != null)
                    {
                        _dbContext.Dispose();
                        _dbContext = null;
                    }
                }
            this.disposed = true;
        }
    }
}
