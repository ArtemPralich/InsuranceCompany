using InsuranceCompany.Core;
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
        IGenericRepository<Client> Client { get; }
    }
}
