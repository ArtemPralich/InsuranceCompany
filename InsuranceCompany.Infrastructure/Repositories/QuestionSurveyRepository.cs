using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class QuestionSurveyRepository : RepositoryBase<QuestionSurvey>
    {
        public QuestionSurveyRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<QuestionSurvey> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public QuestionSurvey GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }

        public QuestionSurvey GetBySurveyId(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.InsuranceSurveyId == Id,
                trackChanges).FirstOrDefault();
        }
    }
}
