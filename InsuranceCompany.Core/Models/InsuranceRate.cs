using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class InsuranceRate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string Title { get; set; }
    public short? CountPaymentsInYear { get; set; }
    public short? CountYears { get; set; }
    public bool? IsFamily { get; set; }
    public bool? IsOldman { get; set; }
    public decimal? BaseCoefficient { get; set; }
    public bool? IsPersonal { get; set; }
    public virtual ICollection<InsuranceRequest> InsuranceRequests { get; } = new List<InsuranceRequest>();
}
