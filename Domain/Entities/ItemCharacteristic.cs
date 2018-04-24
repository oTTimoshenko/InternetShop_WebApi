using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ItemCharacteristic
    {
        [Key]
        public int CharacteristicId { get; set; }
        public double DisplayDiagonal { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; } // Memory of item
        public double Camera { get; set; }

    }
}
