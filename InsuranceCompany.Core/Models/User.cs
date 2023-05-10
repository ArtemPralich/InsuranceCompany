using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsuranceCompany.Core.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [ForeignKey(nameof(Client))]
        public Guid? ClientId { get; set; }

        public virtual Client? Client { get; set; }

        [ForeignKey(nameof(Agent))]
        public Guid? AgentId { get; set; }

        public virtual Agent? Agent { get; set; }
    }
}
