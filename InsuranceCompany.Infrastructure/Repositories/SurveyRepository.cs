﻿using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceCompany.Infrastructure.Repositories
{
    public class SurveyRepository : RepositoryBase<InsuranceSurvey>
    {
        public SurveyRepository(InsuranceCompanyContext repositoryContext) : base(repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IEnumerable<InsuranceSurvey> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges).Include(i => i.QuestionSurveys).ThenInclude(i => i.Question).ToList();
        }

        public InsuranceSurvey GetById(Guid Id, bool trackChanges)
        {
            return FindByCondition(x => x.Id == Id,
                trackChanges).FirstOrDefault();
        }
    }
}
