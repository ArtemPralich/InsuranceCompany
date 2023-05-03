using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Core.Configuration
{
    public  class InsuranceTypeSurveyConfiguration : IEntityTypeConfiguration<InsuranceTypeSurvey>
    {
        public void Configure(EntityTypeBuilder<InsuranceTypeSurvey> builder)
        {
            //builder.HasData(
            //new InsuranceTypeSurvey
            //{
            //    Id = new Guid("5A0D244C-9A62-4B9D-EB10-08DB30F1069A"),
            //    InsuranceRateId = new Guid("5A0D244C-9A62-4B9D-EB10-08DB30F1069B"),
            //    InsuranceSurveyId = new Guid("F61CCC36-5EDE-4769-3083-08DB39C03B5B"),
            //},
            //new InsuranceTypeSurvey
            //{
            //    Id = new Guid("8CD43F71-1D6A-4A45-8974-6A4D9F6749ED"),
            //    InsuranceRateId = new Guid("71718911-3BE9-4921-EB0F-08DB30F1069A"),
            //    InsuranceSurveyId = new Guid("F61CCC36-5EDE-4769-3083-08DB39C03B5B"),
            //});
        }
    }
}
