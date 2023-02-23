using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class InsuranceSurvey
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<InsuranceTypeSurvey> InsuranceTypeSurveys { get; } = new List<InsuranceTypeSurvey>();
}
