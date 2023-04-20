using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InsuranceTypeSurveyRepository : RepositoryBase<InsuranceTypeSurvey>
    {
        public InsuranceTypeSurveyRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceTypeSurvey> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public InsuranceTypeSurvey GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }
    }
}
