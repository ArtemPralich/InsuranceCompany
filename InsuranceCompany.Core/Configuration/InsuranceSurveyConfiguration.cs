using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Configuration
{
    public class InsuranceSurveyConfiguration : IEntityTypeConfiguration<InsuranceSurvey>
    {
        public void Configure(EntityTypeBuilder<InsuranceSurvey> builder)
        {
            builder.HasData(
            new InsuranceSurvey
            {
                Id = new Guid("F61CCC36-5EDE-4769-3083-08DB39C03B5B"),
                Title = "Состояние здоровья",
                Description = "О состоянии здоровья",
            });
        }
    }
}
