using InsuranceCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core
{
    public class InsuranceRateTemplate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid InsuranceRateId { get; set; }
        public InsuranceRate InsuranceRate { get; set; }

        public Guid TemplateId { get; set; }
        public Template Template { get; set; }
    }
}
