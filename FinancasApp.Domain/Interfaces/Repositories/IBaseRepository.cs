using System;
using System.Collections.Generic;
using System.Text;

namespace FinancasApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
        TEntity? GetById(Guid id);
    }
}
