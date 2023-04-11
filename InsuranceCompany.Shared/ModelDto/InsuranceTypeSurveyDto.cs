using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceTypeSurveyDto
    {
        public Guid Id { get; set; }
        public Guid? InsuranceSurveyId { get; set; }
        public Guid? InsuranceRateId { get; set; }
        public virtual InsuranceSurveyDto? InsuranceSurvey { get; set; }
    }
}
