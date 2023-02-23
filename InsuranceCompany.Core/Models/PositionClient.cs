using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class PositionClient
{
    public Guid Id { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? PositionId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Position? Position { get; set; }
}
