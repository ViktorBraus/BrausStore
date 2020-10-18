using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Book
    {
        [HiddenInput(DisplayValue=false)]
        [Display(Name="ID")]
        public int BookId { get; set; }

        [Display(Name="Назва книги")]
        [Required(ErrorMessage ="Будь ласка, вкажіть назву книги")]
        public string Name { get; set; }
        
        [Display(Name = "Автор книги")]
        [Required(ErrorMessage = "Будь ласка, вкажіть ім'я автора")]
        public string Author { get; set; }

        [Display(Name = "Картинка")]
        public byte[] Picture { get; set; }//поменял байт на имадж

        [DataType(DataType.MultilineText)]
        [Display(Name = "Опис книги")]
        [Required(ErrorMessage = "Будь ласка, вкажіть опис книиги")]
        public string Description { get; set; }

        [Display(Name = "Жанр книги")]
        [Required(ErrorMessage = "Будь ласка, вкажіть жанр твору")]
        public string Genre { get; set; }

        [Display(Name = "Ціна книги (грн)")]
        [Required]
        [Range(0.01,double.MaxValue,ErrorMessage = "Будь ласка, вкажіть додатню ціну книги")]
        public decimal Price { get; set; }

    }
}
