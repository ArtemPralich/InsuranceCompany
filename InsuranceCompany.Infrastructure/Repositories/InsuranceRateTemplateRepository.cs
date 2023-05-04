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
    public class InsuranceRateTemplateRepository : RepositoryBase<InsuranceRateTemplate>
    {
        public InsuranceRateTemplateRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceRateTemplate> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public InsuranceRateTemplate GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id, trackChanges).FirstOrDefault();
        }
        public void UpdateRange(List<InsuranceRateTemplate> insuredPersons)
        {
            RepositoryContext.Set<InsuranceRateTemplate>().UpdateRange(insuredPersons);
        }
        public void DeleteRange(List<InsuranceRateTemplate> insuredPersons)
        {
            RepositoryContext.Set<InsuranceRateTemplate>().RemoveRange(insuredPersons);
        }
        public void CreateRange(List<InsuranceRateTemplate> insuredPersons)
        {
            RepositoryContext.Set<InsuranceRateTemplate>().AddRange(insuredPersons);
        }
    }
}
