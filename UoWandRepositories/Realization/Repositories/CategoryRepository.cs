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
using Domain.Interfaces;

namespace UoWandRepositories.Repositories
{
    public class CategoryRepository:ShopGenericRepository<CategoryUoW, Category>, ICategoryRepository
    {
        public CategoryRepository(IEFshopContext context, IMapper mapper)
            : base(context, mapper)
        { }

        public CategoryUoW GetById(int id)
        {
            var entity = mapper.Map<CategoryUoW>(_dbset.Include(x => x.Items).Where(x => x.CategoryId == id).FirstOrDefault());
            return entity;
        }
    }
}
