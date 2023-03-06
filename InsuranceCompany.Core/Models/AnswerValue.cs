using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class AnswerValue
{
    public Guid Id { get; set; }

    public string? Value { get; set; }

    [ForeignKey(nameof(InsuranceRequest))]
    public Guid? InsuranceRequestId { get; set; }

    [ForeignKey(nameof(Question))]
    public Guid? QuestionId { get; set; }

    public virtual InsuranceRequest? InsuranceRequest { get; set; }

    public virtual Question? Question { get; set; }
}
