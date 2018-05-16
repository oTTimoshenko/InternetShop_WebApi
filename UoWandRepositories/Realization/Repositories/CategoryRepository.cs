using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;
using UoWandRepositories.Interfaces;
using AutoMapper;

namespace UoWandRepositories.Repositories
{
    public class CategoryRepository:ShopGenericRepository<CategoryUoW>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            : base(context)
        {

        }

        public CategoryUoW GetById(int id)
        {
            return Mapper.Map<Category, CategoryUoW>(_dbset.Include(x => x.Items).Where(x => x.CategoryId == id).FirstOrDefault());
        }
    }
}
