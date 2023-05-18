using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class DocumentRepository : RepositoryBase<Document>
    {
        public DocumentRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<Document> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }

        public Document GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id, trackChanges).FirstOrDefault();
        }

        public void DeleteRange(List<Document> documents)
        {
            RepositoryContext.Documents.RemoveRange(documents);
        }
    }
}
