using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoWandRepositories.Entities;

namespace UoWandRepositories.Interfaces
{
    public interface ICategoryRepository:IShopGenericRepository<CategoryUoW, Category>
    {
        CategoryUoW GetById(int id);
    }
}
