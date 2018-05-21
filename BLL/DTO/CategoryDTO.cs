using System.Collections.Generic;

namespace BLL.DTO
{
    public class CategoryDTO
    {
      
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<ItemDTO> Items { get; set; }

        public CategoryDTO()
        {
            Items = new List<ItemDTO>();
        }
    }
}
