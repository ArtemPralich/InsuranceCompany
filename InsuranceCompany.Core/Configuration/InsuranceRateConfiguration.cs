using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Configuration
{
    public class InsuranceRateConfiguration : IEntityTypeConfiguration<InsuranceRate>
    {
        public void Configure(EntityTypeBuilder<InsuranceRate> builder)
        {
            builder.HasData(
            new InsuranceRate
            {
                Id = new Guid("71718911-3BE9-4921-EB0F-08DB30F1069A"),
                CountPaymentsInYear = 12,
                CountYears = 5,
                IsFamily = false,
                IsOldman = true,
                IsPersonal = false,
                Title = "Пенсионный страховой запрос с ежемесечной оплатой",
                BaseCoefficient = 30,
            },
            new InsuranceRate
            {
                Id = new Guid("5A0D244C-9A62-4B9D-EB10-08DB30F1069B"),
                CountPaymentsInYear = 4,
                CountYears = 5,
                IsFamily = false,
                IsOldman = true,
                IsPersonal = false,
                Title = "Пенсионный страховой запрос с ежесезонной оплатой",
                BaseCoefficient = 30
            },
           new InsuranceRate
           {
               Id = new Guid("DAFE171C-3F15-4D88-EB11-08DB30F1069A"),
               CountPaymentsInYear = 1,
               CountYears = 5,
               IsFamily = false,
               IsOldman = true,
               IsPersonal = false,
               Title = "Пенсионный страховой запрос с оплатой раз в год",
               BaseCoefficient = 30
           });
        }
    }
}
