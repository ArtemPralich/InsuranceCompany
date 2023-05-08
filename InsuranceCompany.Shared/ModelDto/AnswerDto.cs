using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class AnswerDto
    {
        public Guid Id { get; set; }

        public string? QuestionAnswer { get; set; }
        public Guid? QuestionId { get; set; }
    }
}
