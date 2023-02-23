using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class AnswerValue
{
    public Guid Id { get; set; }

    public string? Value { get; set; }

    public Guid? InsuranceRequestId { get; set; }

    public Guid? QuestionId { get; set; }

    public virtual InsuranceRequest? InsuranceRequest { get; set; }

    public virtual Question? Question { get; set; }
}
