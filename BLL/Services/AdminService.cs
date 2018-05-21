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

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category = mapper.Map<CategoryUoW>(categoryDTO);
            db.Categories.Add(category);
            db.Save();
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = mapper.Map<CategoryUoW>(categoryDTO);
            db.Categories.Edit(category);
            db.Save();
        }

        public void RemoveCategory(int Id)
        {
            db.Categories.DeleteById(Id);
            db.Save();
        }

        public void AddItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO)
        {
            var itemCharacteristic = mapper.Map<ItemCharacteristicUoW>(itemCharacteristicsDTO);
            db.ItemCharacteristics.Add(itemCharacteristic);
            db.Save();
        }

        public void UpdateItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO)
        {
            var itemCharacteristic = mapper.Map<ItemCharacteristicUoW>(itemCharacteristicsDTO);
            db.ItemCharacteristics.Edit(itemCharacteristic);
            db.Save();
        }

        public void RemoveItemCharacteristic(int Id)
        {
            db.ItemCharacteristics.DeleteById(Id);
            db.Save();
        }

        public void AddItem(ItemDTO itemDTO)
        {
            var item = mapper.Map<ItemUoW>(itemDTO);
            db.Items.Add(item);
            db.Save();
        }

        public void UpdateItem(ItemDTO itemDTO)
        {
            var item = mapper.Map<ItemUoW>(itemDTO);
            db.Items.Edit(item);
            db.Save();
        }

        public void RemoveItem(int Id)
        {
            db.Items.DeleteById(Id);
            db.Save();
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
