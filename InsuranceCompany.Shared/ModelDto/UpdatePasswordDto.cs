using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class UpdatePasswordDto
    {
        public string Password { get; set; }
        public string OldPassword { get; set; }
    }
}
