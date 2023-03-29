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
        public string PersonalCode { get; set; }
        public bool? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
