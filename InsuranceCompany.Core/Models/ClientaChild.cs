using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class ClientaChild
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(Client))]
    public Guid? ClientId { get; set; }

    [ForeignKey(nameof(Child))]
    public Guid? ChildId { get; set; }

    public virtual Child? Child { get; set; }

    public virtual Client? Client { get; set; }
}
