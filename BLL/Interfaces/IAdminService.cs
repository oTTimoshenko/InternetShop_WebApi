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
        void UpdateCategory(CategoryDTO categoryDTO);
        void RemoveCategory(int Id);

        void AddItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO);
        void UpdateItemCharacteristic(ItemCharacteristicsDTO itemCharacteristicsDTO);
        void RemoveItemCharacteristic(int Id);

        void AddItem(ItemDTO itemDTO);
        void UpdateItem(ItemDTO itemDTO);
        void RemoveItem(int Id);

        CategoryDTO GetCategory(int Id);
        ItemCharacteristicsDTO GetItemCharacteristics(int Id);
        ItemDTO GetItem(int Id);
        OrderDTO GetOrder(int Id);

        void Dispose(bool disposing);
    }
}
