using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class RegistrationClientDto
    {

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm password is required")]
        public string ConfirmPassword { get; set; }
    }
}
