using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceStatusDto
    {
        public Guid Id { get; set; }

        public string? Status { get; set; }

        public string? Color { get; set; }
        public bool? IsDisabledForms { get; set; }
        public bool? IsDisabledDocuments { get; set; }
    }
}
