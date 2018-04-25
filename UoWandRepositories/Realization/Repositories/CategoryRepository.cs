using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Interfaces;

namespace UoWandRepositories.Repositories
{
    public class CategoryRepository:ShopGenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DbContext context)
            : base(context)
        {

        }

        public Category GetById(int id)
        {
            return _dbset.Include(x => x.Items).Where(x => x.CategoryId == id).FirstOrDefault();
        }
    }
}
