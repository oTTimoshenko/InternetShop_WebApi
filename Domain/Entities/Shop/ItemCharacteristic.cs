using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ItemCharacteristic
    {
        [Key]
        [ForeignKey("Item")]
        public int ItemCharacteristicId { get; set; }
        public double DisplayDiagonal { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; } // Memory of item
        public double Camera { get; set; }

        public Item Item { get; set; }
    }
}
