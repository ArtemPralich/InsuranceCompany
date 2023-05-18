using InsuranceCompany.Core.Models;
using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Create
{
    public class CreateClientDto
    { 
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PersonalCode { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
