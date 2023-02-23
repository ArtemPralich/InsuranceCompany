using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class InsuranceStatus
{
    public Guid Id { get; set; }

    public string? Status { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<InsuranceRequest> InsuranceRequests { get; } = new List<InsuranceRequest>();
}
