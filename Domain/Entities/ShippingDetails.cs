using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class ShippingDetails
    {
        [Required(ErrorMessage = "Вкажіть ваше ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Адреса доставки")]
        [Display(Name = "Перша адреса доставки")]
        public string Line1 { get; set; }

        [Required(ErrorMessage = "Вкажіть місто")]
        [Display(Name = "Місто")]
        public string City { get; set; }

        [Required(ErrorMessage = "Вкажіть країну")]
        [Display(Name = "Країна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
