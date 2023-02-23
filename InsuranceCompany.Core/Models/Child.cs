using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Child
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public short? Age { get; set; }

    public virtual ICollection<ClientaChild> ClientaChildren { get; } = new List<ClientaChild>();
}
