using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class Answer
{
    public Guid Id { get; set; }

    public string? Answer1 { get; set; }

    public Guid? QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}
