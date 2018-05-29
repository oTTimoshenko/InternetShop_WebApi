using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class OrderView
    {
        public int OrderId { get; set; }
        
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public StateView State { get; set; }

        public ICollection<ItemView> Items { get; set; }

        public OrderView()
        {
            Items = new List<ItemView>();
        }
    }
    public enum StateView
    {
        Confirmed,
        In_process,
        Declined
    }
}