using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Client
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public bool? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<ClientaChild> ClientaChildren { get; } = new List<ClientaChild>();

    public virtual ICollection<PositionClient> PositionClients { get; } = new List<PositionClient>();
}
