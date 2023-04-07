using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InsuranceStatusRepository : RepositoryBase<InsuranceStatus>
    {
        public InsuranceStatusRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceStatus> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public InsuranceStatus GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }

        public InsuranceStatus GetByStatus(string status, bool trackChanges)
        {
            return FindByCondition(x => x.Status == status,
                trackChanges).FirstOrDefault();
        }
    }
}
