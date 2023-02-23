using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class InsuranceRate
{
    public Guid Id { get; set; }

    public decimal? BasePayment { get; set; }

    public decimal? UnitPayment { get; set; }

    public virtual ICollection<InsuranceRequest> InsuranceRequests { get; } = new List<InsuranceRequest>();
}
