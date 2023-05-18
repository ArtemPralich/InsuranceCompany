using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class AuthentificatedUser
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
