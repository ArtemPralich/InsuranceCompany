using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompany.MobileClient.Models
{
    public class InsuredPerson
    {
        public Guid? Id { get; set; }
        public bool? IsMainInsuredPerson { get; set; }

        public Guid? ClientId { get; set; }
        public Guid? InsuranceRequestId { get; set; }

        public virtual Client Client { get; set; }
    }
}
