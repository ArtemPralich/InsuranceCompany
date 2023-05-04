using InsuranceCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core
{
    public class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Title { get; set; }

        public string? Path { get; set; }
        [ForeignKey(nameof(InsuranceRequest))]
        public Guid? InsuranceRequestId { get; set; }

        [ForeignKey(nameof(Template))]
        public Guid? TemplateId { get; set; }

        public virtual InsuranceRequest? InsuranceRequest { get; set; }

        public virtual Template? Template { get; set; }

    }
}
