using InsuranceCompany.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core;

public partial class Client
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string PersonalCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string Address { get; set; }
    public bool? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public virtual ICollection<ClientaChild> ClientaChildren { get; } = new List<ClientaChild>();
    public virtual ICollection<InsuredPerson> InsuredPersons { get; } = new List<InsuredPerson>();
    public virtual ICollection<PositionClient> PositionClients { get; } = new List<PositionClient>();
    public virtual ICollection<User> Users { get; } = new List<User>();
}
