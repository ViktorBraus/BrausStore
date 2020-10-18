using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Domain.Entities
{
   public class Register
    {
            [Required]
            public string Email { get; set; }

            [Required]
            public int Year { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [Compare("Password", ErrorMessage = "Паролі не співпадають")]
            [DataType(DataType.Password)]
            public string PasswordConfirm { get; set; }
    }
}
