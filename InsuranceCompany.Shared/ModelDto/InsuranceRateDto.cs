using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceRateDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public short? CountPaymentsInYear { get; set; }
        public short? CountYears { get; set; }
        public bool? IsFamily { get; set; }
        public bool? IsOldman { get; set; }
        public decimal? BaseCoefficient { get; set; }
        public bool? IsPersonal { get; set; }

        public virtual ICollection<InsuranceTypeSurveyDto> InsuranceTypeSurveys { get; } = new List<InsuranceTypeSurveyDto>();
    }
}
