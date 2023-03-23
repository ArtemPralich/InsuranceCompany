using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Shared.ModelDto
{
    public class InsuranceRequestDto
    {
        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd { get; set; }


        public Guid? AgentId { get; set; }


        public Guid? InsuranceRateId { get; set; }

        public Guid? InsuranceStatusId { get; set; }

        public virtual Agent? Agent { get; set; }

        public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

        public virtual InsuranceRate? InsuranceRate { get; set; }

        public virtual InsuranceStatus? InsuranceStatus { get; set; }
    }
}
