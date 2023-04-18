using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Update
{
    public class UpdateInsuredPersonDto
    {
        public Guid Id { get; set; }
        public bool IsMainInsuredPerson { get; set; }
        public virtual UpdateClientDto? Client { get; set; }

    }
}
