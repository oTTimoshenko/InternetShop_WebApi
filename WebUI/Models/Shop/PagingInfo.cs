using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebUI.Models
{
    public class PagingInfo
    {
        [Required]
        public int TotalItems { get; set; } //Count of Items

        [Required]
        [Range(4, 10, ErrorMessage = "Некоректное количество елементов на странице")]
        public int ItemsPerPage { get; set; } //Count of items on one page

        [Required]
        [RegularExpression(@"[1-9]([0-9])*", ErrorMessage = "Некоректный номер страницы")]
        public int CurrentPage { get; set; } // number of current page

        public int TotalPages //Count of all pages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}