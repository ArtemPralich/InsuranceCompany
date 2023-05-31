using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class RegistrationUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
