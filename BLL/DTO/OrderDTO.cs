using System;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime Time { get; set; }
        public double Price { get; set; }
        public StateDTO State { get; set; } = StateDTO.In_process;

        public ICollection<ItemDTO> Items { get; set; }

        public OrderDTO()
        {
            Items = new List<ItemDTO>();
        }
    }

    public enum StateDTO
    {
        Confirmed,
        In_process,
        Declined
    }
}
