using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class ClientaChild
{
    public Guid Id { get; set; }

    public Guid? ClientId { get; set; }

    public Guid? ChildId { get; set; }

    public virtual Child? Child { get; set; }

    public virtual Client? Client { get; set; }
}
