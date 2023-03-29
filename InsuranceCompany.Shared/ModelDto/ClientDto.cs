using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public bool? Gender { get; set; }
        public string? PersonalCode { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
