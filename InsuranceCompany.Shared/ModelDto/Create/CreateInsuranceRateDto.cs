using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Create
{
    public class CreateInsuranceRateDto
    {
        public decimal? BasePayment { get; set; }
        public decimal? UnitPayment { get; set; }
    }
}
