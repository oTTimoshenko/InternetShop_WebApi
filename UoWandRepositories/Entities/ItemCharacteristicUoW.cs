using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoWandRepositories.Entities
{
    public  class ItemCharacteristicUoW
    {
        public int ItemCharacteristicId { get; set; }
        public double DisplayDiagonal { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; }
        public double Camera { get; set; }

        public ItemUoW Item { get; set; }
    }
}
