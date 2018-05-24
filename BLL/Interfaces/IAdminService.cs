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
        bool AddCategory(CategoryDTO categoryDTO);
        bool UpdateCategory(CategoryDTO categoryDTO);
        bool RemoveCategory(int Id);

        bool AddItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO);
        bool UpdateItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO);
        bool RemoveItemCharacteristic(int Id);

        bool AddItem(ItemDTO itemDTO);
        bool UpdateItem(ItemDTO itemDTO);
        bool RemoveItem(int Id);

        CategoryDTO GetCategory(int Id);
        ItemCharacteristicsDTO GetItemCharacteristics(int Id);
        ItemDTO GetItem(int Id);
        OrderDTO GetOrder(int Id);

        void Dispose(bool disposing);
    }
}
