using InsuranceCompany.Core.Models;
using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Create
{
    public class CreateInsuranceRequestDto
    {
        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd { get; set; }

        public decimal Cost { get; set; }

        public virtual CreateClientDto Client { get; set; }
        public virtual CreateInsuranceRateDto? InsuranceRate { get; set; }
    }
}
