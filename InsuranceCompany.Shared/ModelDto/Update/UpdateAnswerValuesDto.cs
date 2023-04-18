using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Update
{
    public class UpdateAnswerValuesDto
    {
        public Guid Id { get; set; }

        public string? Value { get; set; }

        public Guid? QuestionId { get; set; }
        public Guid? InsuranceSurveyId { get; set; }
    }
}
