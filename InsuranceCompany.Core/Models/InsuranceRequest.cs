using System;
using System.Collections.Generic;

namespace InsuranceCompany.Core;

public partial class InsuranceRequest
{
    public Guid Id { get; set; }

    public DateTime? DateOfStart { get; set; }

    public DateTime? DateOfEnd { get; set; }

    public Guid? AgentId { get; set; }

    public Guid? InsuranceRateId { get; set; }

    public Guid? InsuranceStatusId { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();

    public virtual InsuranceRate? InsuranceRate { get; set; }

    public virtual InsuranceStatus? InsuranceStatus { get; set; }
}
