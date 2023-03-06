﻿using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure
{
    public class RepositoryManager : IRepositoryManager
    {
        private IGenericRepository _agentRepository;
        private IGenericRepository _clientRepository;
        private InsuranceCompanyContext _repositoryContext;
        public RepositoryManager(InsuranceCompanyContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IGenericRepository Agent
        {
            get
            {
                if (_agentRepository == null)
                    _agentRepository = new GenericRepository<Agent>(_repositoryContext);
                return _agentRepository;
            }
        }
        public IGenericRepository Client
        {
            get
            {
                if (_clientRepository == null)
                    _clientRepository = new GenericRepository<Client>(_repositoryContext);
                return _clientRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();

    }
}