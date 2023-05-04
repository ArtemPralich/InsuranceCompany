using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class Answer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? QuestionAnswer { get; set; }

    [ForeignKey(nameof(Question))]
    public Guid? QuestionId { get; set; }

    public virtual Question? Question { get; set; }
}
