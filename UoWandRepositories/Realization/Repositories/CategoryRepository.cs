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
    public class CategoryRepository:ShopGenericRepository<CategoryUoW, Category>, ICategoryRepository
    {
        public CategoryRepository(string connectionString, IMapper mapper)
            : base(connectionString, mapper)
        { }

        public CategoryUoW GetById(int id)
        {
            var entity = mapper.Map<CategoryUoW>(_dbset.Include(x => x.Items).Where(x => x.CategoryId == id).FirstOrDefault());
            return entity;
        }
    }
}
