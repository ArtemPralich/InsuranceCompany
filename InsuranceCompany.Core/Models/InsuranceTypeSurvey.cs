using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class InsuranceTypeSurvey
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [ForeignKey(nameof(InsuranceSurvey))]
    public Guid? InsuranceSurveyId { get; set; }

    [ForeignKey(nameof(InsuranceRate))]
    public Guid? InsuranceRateId { get; set; }

    public virtual InsuranceSurvey? InsuranceSurvey { get; set; }

    public virtual InsuranceRate? InsuranceRate { get; set; }
}
