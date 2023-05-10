using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            new IdentityRole
            {
                Id = "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                Name = "Agent",
                NormalizedName = "AGENT"
            },
            new IdentityRole
            {

                Id = "aa30174a-40e9-40cc-a660-f123ff11fa04",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new IdentityRole
            {

                Id = "7cae6025-c9d0-40bd-b780-372485e90ce0",
                Name = "Client",
                NormalizedName = "CLIENT"
            }
            );
        }
    }
}