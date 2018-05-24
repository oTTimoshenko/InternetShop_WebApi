using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;
using AutoMapper;
using UoWandRepositories.Entities;

namespace BLL.Services
{
    public class AdminService : IAdminService
    {
        private readonly IShopUnitOfWork db;
        private readonly IMapper mapper;

        public AdminService(IShopUnitOfWork _db, IMapper mapper)
        {
            db = _db;
            this.mapper = mapper;
        }

        public bool AddCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = mapper.Map<CategoryUoW>(categoryDTO);
                db.Categories.Add(category);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCategory(CategoryDTO categoryDTO)
        {
            try
            {
                var category = mapper.Map<CategoryUoW>(categoryDTO);
                db.Categories.Edit(category);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool RemoveCategory(int Id)
        {
            try
            {
                db.Categories.DeleteById(Id);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool AddItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO)
        {
            try
            {
                var itemCharacteristic = mapper.Map<ItemCharacteristicUoW>(itemCharacteristicsDTO);
                db.ItemCharacteristics.Add(itemCharacteristic);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool UpdateItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO)
        {
            try
            {
                var itemCharacteristic = mapper.Map<ItemCharacteristicUoW>(itemCharacteristicsDTO);
                db.ItemCharacteristics.Edit(itemCharacteristic);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool RemoveItemCharacteristic(int Id)
        {
            try
            {
                db.ItemCharacteristics.DeleteById(Id);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool AddItem(ItemDTO itemDTO)
        {
            try
            {
                var item = mapper.Map<ItemUoW>(itemDTO);
                db.Items.Add(item);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool UpdateItem(ItemDTO itemDTO)
        {
            try
            {
                var item = mapper.Map<ItemUoW>(itemDTO);
                db.Items.Edit(item);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public bool RemoveItem(int Id)
        {
            try
            {
                db.Items.DeleteById(Id);
                db.Save();
            }
            catch (Exception exc)
            {
                return false;
            }
            return true;
        }

        public CategoryDTO GetCategory(int Id)
        {
            return mapper.Map<CategoryDTO>(db.Categories.GetById(Id));
        }

        public ItemCharacteristicsDTO GetItemCharacteristics(int Id)
        {
            return mapper.Map<ItemCharacteristicsDTO>(db.ItemCharacteristics.GetById(Id));
        }

        public ItemDTO GetItem(int Id)
        {
            return mapper.Map<ItemDTO>(db.Items.GetById(Id));
        }

        public OrderDTO GetOrder(int Id)
        {
            return mapper.Map<OrderDTO>(db.Orders.GetById(Id));
        }

        public void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}
