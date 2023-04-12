using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class QuestionSurvey
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(InsuranceSurvey))]
    public Guid? InsuranceSurveyId { get; set; }

    [ForeignKey(nameof(Question))]
    public Guid? QuestionId { get; set; }

    public virtual Question? Question { get; set; }

    public virtual InsuranceSurvey? InsuranceSurvey { get; set; }
}
