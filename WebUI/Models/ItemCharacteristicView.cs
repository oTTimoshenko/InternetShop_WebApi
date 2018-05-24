using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class ItemCharacteristicView
    {
        public int ItemCharacteristicId { get; set; }
        public double DisplayDiagonal { get; set; }
        public int RAM { get; set; }
        public int Memory { get; set; }
        public double Camera { get; set; }

        //public ItemView Item { get; set; }
    }
}