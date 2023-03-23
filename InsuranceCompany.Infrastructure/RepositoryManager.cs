using InsuranceCompany.Core;
using InsuranceCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure
{
    public class RepositoryManager : IRepositoryManager
    {
        private IGenericRepository<Agent> _agentRepository;
        private ClientRepository _clientRepository;
        private InsuranceRequestRepository _insuranceRequest;

        private InsuranceCompanyContext _repositoryContext;
        public RepositoryManager(InsuranceCompanyContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IGenericRepository<Agent> Agent
        {
            get
            {
                if (_agentRepository == null)
                    _agentRepository = new GenericRepository<Agent>(_repositoryContext);
                return _agentRepository;
            }
        }
        public ClientRepository Client
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new ClientRepository(_repositoryContext);
                return _clientRepository;
            }
        }

        public InsuranceRequestRepository InsuranceRequest
        {
            get
            {
                if (_insuranceRequest == null)
                    _insuranceRequest = new InsuranceRequestRepository(_repositoryContext);
                return _insuranceRequest;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();

    }
}
