﻿using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InsuranceCompany.Infrastructure
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll(bool trackChanges);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}