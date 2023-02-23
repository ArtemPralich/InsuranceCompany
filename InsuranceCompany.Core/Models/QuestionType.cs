using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class QuestionType
{
    public Guid Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
