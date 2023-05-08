using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>
    {
        public AnswerRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<Answer> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Answer GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }

        public void CreateRange(List<Answer> questionSurveys)
        {
            RepositoryContext.Set<Answer>().AddRange(questionSurveys);
        }

        public void DeleteRange(List<Answer> questionSurveys)
        {
            RepositoryContext.Set<Answer>().RemoveRange(questionSurveys);
        }
    }
}
