using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class RuleTypeRequest
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(RuleRequest))]
    public Guid? RuleId { get; set; }

    [ForeignKey(nameof(TypeRequest))]
    public Guid? TypeId { get; set; }

    public virtual RuleRequest? Rule { get; set; }

    public virtual TypeRequest? Type { get; set; }
}
