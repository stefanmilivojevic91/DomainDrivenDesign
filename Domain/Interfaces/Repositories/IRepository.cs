using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IRepository<TModel>
        where TModel: class, new()
    {
        Task<IEnumerable<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate);
        Task<TModel> GetSingleAsync(Expression<Func<TModel, bool>> predicate);
        Task<TModel> SaveAsync(TModel entity);
        Task<TModel> UpdateAsync(TModel entity);
        Task<bool> DeleteAsync(TModel entity);
    }
}
