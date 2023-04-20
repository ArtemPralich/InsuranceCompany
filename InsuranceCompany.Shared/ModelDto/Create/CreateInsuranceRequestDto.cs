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
        public Guid? InsuranceStatusId { get; set; }
        public Guid? InsuranceRateId { get; set; }
        public decimal Cost { get; set; }
        public decimal? BasePayment { get; set; }
        public decimal? UnitPayment { get; set; }
        public decimal? Coefficient { get; set; }
        public virtual CreateClientDto Client { get; set; }
    }
}
