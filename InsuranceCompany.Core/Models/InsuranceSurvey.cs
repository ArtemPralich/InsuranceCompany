using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class InsuranceSurvey
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
    public bool? IsDeactivated { get; set; }

    public virtual ICollection<InsuranceTypeSurvey> InsuranceTypeSurveys { get; } = new List<InsuranceTypeSurvey>();
    public virtual ICollection<QuestionSurvey> QuestionSurveys { get; } = new List<QuestionSurvey>();
}
