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
        InsuranceRateRepository InsuranceRate { get; }
        QuestionRepository Question { get; }
        InsuranceStatusRepository InsuranceStatus { get; }
        SurveyRepository InsuranceSurvey { get; }
        QuestionTypeRepository QuestionType { get; }
        InsuranceTypeSurveyRepository InsuranceTypeSurvey { get; }
        InsuredPersonRepository InsuredPerson { get; }
        TemplateRepository Template { get; }
        DocumentRepository Document { get; }
        InsuranceRateTemplateRepository InsuranceRateTemplate { get; }
        public QuestionSurveyRepository QuestionSurvey { get; }
    }
}
