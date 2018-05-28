using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class WebApiFilterCriteries
    {
        public int[] RAM { get; set; }
        public double[] Camera { get; set; }
        public double[] DisplayDiagonal { get; set; }
        public int[] MemorySize { get; set; }
    }
}