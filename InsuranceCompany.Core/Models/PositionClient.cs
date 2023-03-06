using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class PositionClient
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(Client))]
    public Guid? ClientId { get; set; }

    [ForeignKey(nameof(Position))]
    public Guid? PositionId { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Position? Position { get; set; }
}
