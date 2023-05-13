using InsuranceCompany.Core.Models;
using InsuranceCompany.Core;
using InsuranceCompany.Shared.ModelDto.Update;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Update
{
    public class UpdateInsuranceDto
    {
        public Guid Id { get; set; }
        public DateTime? DateOfStart { get; set; }
        public DateTime? DateOfEnd { get; set; }
        public Guid? InsuranceStatusId { get; set; }
        public decimal Cost { get; set; }
        public decimal? BasePayment { get; set; }
        public decimal? UnitPayment { get; set; }
        public decimal? Coefficient { get; set; }
        public decimal? Benefits { get; set; }
        public virtual ICollection<UpdateAnswerValuesDto> AnswerValues { get; } = new List<UpdateAnswerValuesDto>();
        public virtual ICollection<UpdateInsuredPersonDto> InsuredPersons { get; } = new List<UpdateInsuredPersonDto>();
    }
}
