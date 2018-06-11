using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.UI.Models
{
   
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
     
    }

   
}
