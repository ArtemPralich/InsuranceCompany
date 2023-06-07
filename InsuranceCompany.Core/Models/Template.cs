using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Models
{
    public class Template
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Text { get; set; }

        public string? Title { get; set; }
        public bool? IsDisabled { get; set; }

        public virtual ICollection<Document> Documents { get; } = new List<Document>();
        public virtual ICollection<InsuranceRateTemplate> InsuranceRateTemplates { get; set; } = new List<InsuranceRateTemplate>();

    }
}
