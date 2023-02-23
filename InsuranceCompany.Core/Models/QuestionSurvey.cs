using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class QuestionSurvey
{
    public Guid Id { get; set; }

    public Guid? SurveyId { get; set; }

    public Guid? QuestionId { get; set; }

    public virtual Question? Question { get; set; }

    public virtual RuleRequest? Survey { get; set; }
}
