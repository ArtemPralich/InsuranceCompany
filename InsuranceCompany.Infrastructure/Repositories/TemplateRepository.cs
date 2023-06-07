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
    public class TemplateRepository : RepositoryBase<Template>
    {
        public TemplateRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<Template> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).Include(t => t.InsuranceRateTemplates).ToList().Where(t => !(t.IsDisabled ?? false));
        }

        public Template GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).Include(t => t.InsuranceRateTemplates).Where(t => !(t.IsDisabled ?? false)).FirstOrDefault();
        }
    }
}
