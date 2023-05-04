using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class TemplateDto
    {
        public Guid Id { get; set; }

        public string? Text { get; set; }

        public string? Title { get; set; }

        public virtual ICollection<string> InsuranceRates { get; set; } = new List<string>();
    }
}
