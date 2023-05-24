using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class ClientRepository : RepositoryBase<Client>
    {
        public ClientRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<Client> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Client GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }

        public Client GetPrivateInfoById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id, trackChanges)
                .Include(i => i.InsuredPersons).ThenInclude(i => i.InsuranceRequest).ThenInclude(i => i.Documents).FirstOrDefault();
        }
    }
}
