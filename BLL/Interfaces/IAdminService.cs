using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAdminService
    {
        void AddCategory(CategoryDTO categoryDTO);
        void RemoveCategory(int categoryId);
        CategoryDTO GetCategory(int categoryId);
    }
}
