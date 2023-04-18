using InsuranceCompany.Core;
using InsuranceCompany.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class InsuredPersonRepository : RepositoryBase<InsuredPerson>
    {
        public InsuredPersonRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuredPerson> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).Include(i => i.Client);
        }

        public InsuredPerson GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }

        public List<InsuredPerson> GetRangeByIds(List<Guid> guids, bool trackChanges)
        {
            return FindByCondition(x => guids.Contains(x.Id),
                trackChanges).Include(i => i.Client).ToList();
        }

        public void UpdateRange(List<InsuredPerson> insuredPersons)
        {
            RepositoryContext.InsuredPersons.UpdateRange(insuredPersons);
        }
    }
}
