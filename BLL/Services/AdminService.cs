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

        public CategoryDTO GetCategory(int categoryId)
        {
            return mapper.Map<CategoryDTO>(db.Categories.GetById(categoryId));
        }

        public void RemoveCategory(int categoryId)
        {
            db.Categories.DeleteById(categoryId);
            db.Save();
        }
    }
}
