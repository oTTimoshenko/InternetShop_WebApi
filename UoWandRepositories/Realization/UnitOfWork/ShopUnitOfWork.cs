using Domain.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;
using UoWandRepositories.Interfaces;
using UoWandRepositories.Repositories;
using Domain.Interfaces;
using AutoMapper;

namespace UoWandRepositories.UnitOfWork
{
    public class ShopUnitOfWork : IShopUnitOfWork //UnitOfWork for predmet area
    {

        private IEFshopContext _dbContext;
        private IMapper _mapper;
        
        private ICategoryRepository categoryRepository;
        private IItemCharacteristicRepository itemCharacteristicRepository;
        private IItemRepository itemRepository;
        private IOrderRepository orderRepository;


        public ShopUnitOfWork(string connectionString, IMapper mapper)
        {
            _dbContext = new EFshopContext(connectionString);
            _mapper = mapper;
        }

        /*public ICategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_dbContext);
                return categoryRepository;
            }
        }

        public IItemCharacteristicRepository ItemCharacteristics
        {
            get
            {
                if (itemCharacteristicRepository == null)
                    itemCharacteristicRepository = new ItemCharacteristicRepository(_dbContext);
                return itemCharacteristicRepository;
            }
        }

        public IItemRepository Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(_dbContext);
                return itemRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_dbContext);
                return orderRepository;
            }
        }*/

        public ICategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(_dbContext, _mapper);
                return categoryRepository;
            }
        }


        public IItemCharacteristicRepository ItemCharacteristics
        {
            get
            {
                if (itemCharacteristicRepository == null)
                    itemCharacteristicRepository = new ItemCharacteristicRepository(_dbContext, _mapper);
                return itemCharacteristicRepository;
            }
        }

        public IItemRepository Items
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(_dbContext, _mapper);
                return itemRepository;
            }
        }

        public IOrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(_dbContext, _mapper);
                return orderRepository;
            }
        }

        public int Save()// Save changes
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
                    }
                }
            this.disposed = true;
        }
    }
}
