using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class TypeRequest
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public short? CountPaymentsInYear { get; set; }

    public short? CountYears { get; set; }

    public decimal? Cost { get; set; }
    
    public virtual ICollection<InsuranceTypeSurvey> InsuranceTypeSurveys { get; } = new List<InsuranceTypeSurvey>();

    public virtual ICollection<RuleTypeRequest> RuleTypeRequests { get; } = new List<RuleTypeRequest>();
}
