using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Data.ViewModels
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "userName is required")]
        public string userName { get; set; }
        //[Required(ErrorMessage = "Email is required")]
        //public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "NewPassword is required and password must more than 8 letters and have number, letters and special character")]
        public string NewPassword { get; set; }
    }
}
