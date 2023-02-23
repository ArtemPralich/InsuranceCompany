using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class RuleRequest
{
    public Guid Id { get; set; }

    public bool? IsChildRequest { get; set; }

    public bool? IsOldman { get; set; }

    public bool? IsDisabledPerson { get; set; }

    public virtual ICollection<QuestionSurvey> QuestionSurveys { get; } = new List<QuestionSurvey>();

    public virtual ICollection<RuleTypeRequest> RuleTypeRequests { get; } = new List<RuleTypeRequest>();
}
