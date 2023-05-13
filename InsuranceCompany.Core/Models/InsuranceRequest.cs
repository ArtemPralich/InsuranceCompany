using InsuranceCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class InsuranceRequest
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime? DateOfStart { get; set; }
    public DateTime? DateOfEnd { get; set; }
    [ForeignKey(nameof(Agent))]
    public Guid? AgentId { get; set; }
    [ForeignKey(nameof(InsuranceRate))]
    public Guid? InsuranceRateId { get; set; }
    [ForeignKey(nameof(InsuranceStatus))]
    public Guid? InsuranceStatusId { get; set; }
    public virtual Agent? Agent { get; set; }
    public decimal Cost { get; set; }
    public decimal? BasePayment { get; set; }
    public decimal? UnitPayment { get; set; }
    public decimal? Benefits { get; set; }
    public decimal? Coefficient { get; set; }
    public bool IsReadyDocuments { get; set; }
    public virtual ICollection<AnswerValue> AnswerValues { get; } = new List<AnswerValue>();
    public virtual ICollection<InsuredPerson> InsuredPersons { get; } = new List<InsuredPerson>();
    public virtual ICollection<Document> Documents { get; } = new List<Document>();
    public virtual InsuranceRate? InsuranceRate { get; set; }
    public virtual InsuranceStatus? InsuranceStatus { get; set; }
}
