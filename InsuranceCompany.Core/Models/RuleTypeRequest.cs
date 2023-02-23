using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class RuleTypeRequest
{
    public Guid Id { get; set; }

    public Guid? RuleId { get; set; }

    public Guid? TypeId { get; set; }

    public virtual RuleRequest? Rule { get; set; }

    public virtual TypeRequest? Type { get; set; }
}
