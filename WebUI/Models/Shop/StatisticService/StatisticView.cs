﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class StatisticView
    {
        public double totalItemsSold { get; set; }
        public double totalItems { get; set; }
        public double totalRevenue { get; set; }
    }
}