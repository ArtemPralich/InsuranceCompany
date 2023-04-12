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
        private InsuranceRateRepository _insuranceRateRepository;

        private InsuranceCompanyContext _repositoryContext;
        private QuestionRepository _questionRepository;
        private SurveyRepository _insuranceSurveyRepository;
        private InsuranceStatusRepository _insuranceStatusRepositoryRepository;
        private QuestionTypeRepository _questionTypeRepository;
        private InsuranceTypeSurveyRepository _insuranceTypeSurvey;
        private QuestionSurveyRepository _questionSurvey;

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

        public InsuranceRateRepository InsuranceRate
        {
            get
            {
                if (_insuranceRateRepository == null)
                    _insuranceRateRepository = new InsuranceRateRepository(_repositoryContext);
                return _insuranceRateRepository;
            }
        }
        
        public QuestionRepository Question 
        {
            get
            {
                if (_questionRepository == null)
                    _questionRepository = new QuestionRepository(_repositoryContext);
                return _questionRepository;
            }
        }

        public InsuranceStatusRepository InsuranceStatus
        {
            get
            {
                if (_insuranceStatusRepositoryRepository == null)
                    _insuranceStatusRepositoryRepository = new InsuranceStatusRepository(_repositoryContext);
                return _insuranceStatusRepositoryRepository;
            }
        }

        public SurveyRepository InsuranceSurvey
        {
            get
            {
                if (_insuranceSurveyRepository == null)
                    _insuranceSurveyRepository = new SurveyRepository(_repositoryContext);
                return _insuranceSurveyRepository;
            }
        }

        public QuestionTypeRepository QuestionType
        {
            get
            {
                if (_questionTypeRepository == null)
                    _questionTypeRepository = new QuestionTypeRepository(_repositoryContext);
                return _questionTypeRepository;
            }
        }

        public InsuranceTypeSurveyRepository InsuranceTypeSurvey
        {
            get
            {
                if (_insuranceTypeSurvey == null)
                    _insuranceTypeSurvey = new InsuranceTypeSurveyRepository(_repositoryContext);
                return _insuranceTypeSurvey;
            }
        }

        public QuestionSurveyRepository QuestionSurvey
        {
            get
            {
                if (_questionSurvey == null)
                    _questionSurvey = new QuestionSurveyRepository(_repositoryContext);
                return _questionSurvey;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();

    }
}
