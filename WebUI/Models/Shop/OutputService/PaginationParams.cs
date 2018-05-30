using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class PaginationParams
    {
        [Required]
        [RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Некоректный номер страницы")]
        public int CurrentPage { get; set; }

        [Required]
        [Range(4, 10, ErrorMessage = "Некоректное количество елементов на странице")]
        public int PageSize { get; set; }
    }
}