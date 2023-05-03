using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto.Create
{
    public class CreateQuestionDto
    {
        public string? Text { get; set; }

        public bool? IsMandatory { get; set; }

        public Guid? QuestionTypeId { get; set; }
        public Guid? SyrveyId { get; set; }

        public List<CreateAnswerDto> Answers { get; set; } = new List<CreateAnswerDto>();
    }
}
