using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class QuestionType
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? Text { get; set; }

    public virtual ICollection<Question> Questions { get; } = new List<Question>();
}
