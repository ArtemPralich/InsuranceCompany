using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
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
        public Guid? Id { get; set; }
        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd { get; set; }


        public Guid? AgentId { get; set; }


        public Guid? InsuranceRateId { get; set; }

        public decimal Cost { get; set; }
        public Guid? InsuranceStatusId { get; set; }

        public virtual Agent? Agent { get; set; }

        public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

        public virtual InsuranceRate? InsuranceRate { get; set; }
        public virtual InsuranceStatusDto? InsuranceStatus { get; set; }
        public virtual ICollection<InsuredPersonDto> InsuredPersons { get; } = new List<InsuredPersonDto>();
        public ClientDto MainClient { get;set; }
    }
}
