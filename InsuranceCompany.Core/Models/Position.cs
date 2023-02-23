using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Position
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Agent> Agents { get; } = new List<Agent>();

    public virtual ICollection<PositionClient> PositionClients { get; } = new List<PositionClient>();
}
