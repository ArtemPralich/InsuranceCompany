using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class QuestionSurvey
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(Survey))]
    public Guid? SurveyId { get; set; }

    [ForeignKey(nameof(Question))]
    public Guid? QuestionId { get; set; }

    public virtual Question? Question { get; set; }

    public virtual RuleRequest? Survey { get; set; }
}
