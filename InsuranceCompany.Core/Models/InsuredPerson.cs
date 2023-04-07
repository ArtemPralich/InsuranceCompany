using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Models
{
    public partial class InsuredPerson
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public bool IsMainInsuredPerson { get; set; }

        [ForeignKey(nameof(Client))]
        public Guid? ClientId { get; set; }

        [ForeignKey(nameof(InsuranceRequest))]
        public Guid? InsuranceRequestId { get; set; }

        public virtual Client? Client { get; set; }

        public virtual InsuranceRequest? InsuranceRequest { get; set; }
    }
}
