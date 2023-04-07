using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuredPersonDto
    {
        public bool IsMainInsuredPerson { get; set; }

        public Guid? ClientId { get; set; }
        public Guid? InsuranceRequestId { get; set; }

        public virtual ClientDto? Client { get; set; }

    }
}
