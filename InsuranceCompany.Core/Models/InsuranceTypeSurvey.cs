using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class InsuranceTypeSurvey
{
    public Guid Id { get; set; }

    [ForeignKey(nameof(InsuranceSurvey))]
    public Guid? InsuranceSurveyId { get; set; }

    [ForeignKey(nameof(TypeRequest))]
    public Guid? TypeRequestId { get; set; }

    public virtual InsuranceSurvey? InsuranceSurvey { get; set; }

    public virtual TypeRequest? TypeRequest { get; set; }
}
