using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class InsuranceRequest
    {
        public Guid? Id { get; set; }
        public DateTime? DateOfStart { get; set; }

        public DateTime? DateOfEnd { get; set; }


        public Guid? AgentId { get; set; }
        public decimal Cost { get; set; }
        public decimal? BasePayment { get; set; }
        public decimal? UnitPayment { get; set; }
        public decimal? Benefits { get; set; }


        public Guid? InsuranceRateId { get; set; }

        public Guid? InsuranceStatusId { get; set; }

        public bool IsReadyDocuments { get; set; }


        public InsuranceRate InsuranceRate { get; set; }
        public InsuranceStatus InsuranceStatus { get; set; }
        public virtual ICollection<InsuredPerson> InsuredPersons { get; set; } = new List<InsuredPerson>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
        public Client MainClient { get; set; }
    }
}
