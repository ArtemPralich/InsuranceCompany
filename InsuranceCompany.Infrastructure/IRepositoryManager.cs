using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure
{
    public interface IRepositoryManager
    {
        void Save();
        IGenericRepository<Agent> Agent { get; }
        ClientRepository Client { get; }
        InsuranceRequestRepository InsuranceRequest { get; }
    }
}
