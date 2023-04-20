using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class Question
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? Text { get; set; }

    public bool? IsMandatory { get; set; }

    [ForeignKey(nameof(QuestionType))]
    public Guid? QuestionTypeId { get; set; }

    public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

    public virtual ICollection<Answer> Answers { get; } = new List<Answer>();

    public virtual ICollection<QuestionSurvey> QuestionSurveys { get; } = new List<QuestionSurvey>();

    public virtual QuestionType? QuestionType { get; set; }
}
