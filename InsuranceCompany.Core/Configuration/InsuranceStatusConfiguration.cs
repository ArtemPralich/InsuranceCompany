using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Configuration
{
    public class InsuranceStatusConfiguration : IEntityTypeConfiguration<InsuranceStatus>
    {
        public void Configure(EntityTypeBuilder<InsuranceStatus> builder)
        {
            builder.HasData(
            new InsuranceStatus
            {
                Id = new Guid("988A1903-D7B0-442B-809E-4FAFBE76B941"),
                Color = "#ffeed0",
                Status = "Создано",
            },
            new InsuranceStatus
            {
                Id = new Guid("8CD43F71-1D6A-4A45-8974-6A4D9F6749ED"),
                Color = "#a0fa5e",
                Status = "Подписано",
            },
           new InsuranceStatus
            {
                Id = new Guid("B74A9704-FF2C-4992-80B5-F22905091835"),
                Color = "#d0f5ff",
                Status = "Заполнено",
            }); ;
        }
    }
}
