using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InsuranceRateRepository : RepositoryBase<InsuranceRate>
    {
        public InsuranceRateRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceRate> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).Include(i => i.InsuranceTypeSurveys).ThenInclude(its => its.InsuranceSurvey).ToList();
        }

        public InsuranceRate GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id, trackChanges).Include(i => i.InsuranceTypeSurveys)
                .ThenInclude(its => its.InsuranceSurvey).ThenInclude(its => its.QuestionSurveys)
                .ThenInclude(its => its.Question).FirstOrDefault();
        }
    }
}
