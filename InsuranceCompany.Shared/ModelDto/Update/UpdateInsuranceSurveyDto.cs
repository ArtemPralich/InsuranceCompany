using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Update
{
    public class UpdateInsuranceSurveyDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<InsuranceRate> InsuranceRates { get; } = new List<InsuranceRate>();
        public virtual ICollection<QuestionDto> Questions { get; } = new List<QuestionDto>();
    }
}
