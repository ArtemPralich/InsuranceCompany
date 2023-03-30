using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InsuranceRequestRepository : RepositoryBase<InsuranceRequest>
    {
        public InsuranceRequestRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceRequest> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).Include(i => i.InsuranceStatus).Include(i => i.InsuranceRate)
                .Include(i => i.InsuredPersons).ThenInclude(i => i.Client).ToList();
        }

        public InsuranceRequest GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }
    }
}
