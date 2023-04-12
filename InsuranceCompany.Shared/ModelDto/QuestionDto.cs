using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class QuestionDto
    {
        public Guid Id { get; set; }

        public string? Text { get; set; }

        public bool? IsMandatory { get; set; }

        public Guid? QuestionTypeId { get; set; }

        public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

        public virtual ICollection<Answer> Answers { get; } = new List<Answer>();


        public virtual QuestionTypeDto? QuestionType { get; set; }
    }
}
