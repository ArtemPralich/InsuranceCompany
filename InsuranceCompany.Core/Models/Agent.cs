using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Agent
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfStart { get; set; }

    public Guid? PositionId { get; set; }

    public virtual ICollection<InsuranceRequest> InsuranceRequests { get; } = new List<InsuranceRequest>();

    public virtual Position? Position { get; set; }
}
