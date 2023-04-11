using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class QuestionTypeRepository : RepositoryBase<QuestionType>
    {
        public QuestionTypeRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<QuestionType> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public QuestionType GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }
    }
}
