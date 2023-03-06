using InsuranceCompany.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceCompany.Infrastructure
{
    public class GenericRepository<T> : RepositoryBase<T>, IGenericRepository<T> where T : class
    {
        public GenericRepository(InsuranceCompanyContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public IEnumerable<T> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).ToList();
        }
        
        void Create(T t)
        {
            base.Create(t);
        }
    }
}
