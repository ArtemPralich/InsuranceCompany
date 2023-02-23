using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Client
{
    public Guid Id { get; set; }

    public decimal? BasePayment { get; set; }

    public decimal? UnitPayment { get; set; }

    public bool? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<ClientaChild> ClientaChildren { get; } = new List<ClientaChild>();

    public virtual ICollection<PositionClient> PositionClients { get; } = new List<PositionClient>();
}
