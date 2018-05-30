using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class ItemCharacteristicView
    {
        public int ItemCharacteristicId { get; set; }

        [Required]
        public double DisplayDiagonal { get; set; }

        [Required]
        public int RAM { get; set; }

        [Required]
        public int Memory { get; set; }

        [Required]
        public double Camera { get; set; }
    }
}