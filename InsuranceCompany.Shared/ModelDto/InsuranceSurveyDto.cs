using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceSurveyDto
    {
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

       public virtual ICollection<Question> Questions { get; } = new List<Question>();
    }
}
