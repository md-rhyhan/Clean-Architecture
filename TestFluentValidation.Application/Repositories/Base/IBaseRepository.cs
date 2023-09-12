using System.Linq.Expressions;
using TestFluentValidation.Application.Models;
using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Application.Repositories.Base;

public interface IBaseRepository<TEntity, TModel, T>
    where TEntity : class, IEntity<T>, new()
    where TModel : class, IEntityVM<T>, new()
    where T : IEquatable<T>
{
    Task<TModel> GetById(T id);
    Task<IEnumerable<TModel>> GetAllAsync();
    Task<List<TModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
    Task<TModel> InsertAsync(TEntity entity);
    Task<TModel> UpdateAsync(T id, TEntity entity);
    Task<TModel> DeleteAsync(T id);
}