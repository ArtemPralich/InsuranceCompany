using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class InsuranceTypeSurvey
{
    public Guid Id { get; set; }

    public Guid? InsuranceSurveyId { get; set; }

    public Guid? TypeRequestId { get; set; }

    public virtual InsuranceSurvey? InsuranceSurvey { get; set; }

    public virtual TypeRequest? TypeRequest { get; set; }
}
