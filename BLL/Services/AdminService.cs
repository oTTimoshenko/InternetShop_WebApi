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
        IShopUnitOfWork db;

        public AdminService(IShopUnitOfWork _db)
        {
            db = _db;
        }

        public void AddCategory(CategoryDTO categoryDTO)
        {
            var category = Mapper.Map<CategoryDTO, CategoryUoW>(categoryDTO);
            db.Categories.Add(category);
            db.Save();
        }

        public CategoryDTO GetCategory(int categoryId)
        {
            return Mapper.Map<CategoryUoW, CategoryDTO>(db.Categories.GetById(categoryId));
        }

        public void RemoveCategory(int categoryId)
        {
            var category = db.Categories.GetById(categoryId);
            db.Categories.Delete(category);
        }
    }
}
