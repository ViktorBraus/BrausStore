using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUA1.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } // Общее кол-во книг
        public int ItemsPerPage { get; set; } // кол-во книг на странице 
        public int CurrentPage { get; set; }// номер текущей страницы
        public int TotalPages //общее количевство страниц
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); 
            }
        }

    }
}