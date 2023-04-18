using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class AnswerValueDto
    {
        public Guid Id { get; set; }

        public string? Value { get; set; }

        [ForeignKey(nameof(InsuranceRequest))]
        public Guid? InsuranceRequestId { get; set; }

        [ForeignKey(nameof(Question))]

        public Guid? QuestionId { get; set; }

        public Guid? InsuranceSurveyId { get; set; }

        public virtual InsuranceRequest? InsuranceRequest { get; set; }

        public virtual Question? Question { get; set; }
    }
}
