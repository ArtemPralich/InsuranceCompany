using System;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using InsuranceCompany.Core.Models;

namespace InsuranceCompany.Core;

public partial class Agent
{

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfStart { get; set; }

    [ForeignKey(nameof(Position))]
    public Guid? PositionId { get; set; }

    public virtual ICollection<InsuranceRequest> InsuranceRequests { get; } = new List<InsuranceRequest>();
    public virtual ICollection<User> Users { get; } = new List<User>();
    public virtual Position? Position { get; set; }
}
