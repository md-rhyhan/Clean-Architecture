using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestFluentValidation.Application.Common;
using TestFluentValidation.Application.Models;
using TestFluentValidation.Domain.Base;

namespace TestFluentValidation.Application.Repositories.Base;

public class BaseRepository<TEntity, TModel, T> : IBaseRepository<TEntity, TModel, T>
    where TEntity : class, IEntity<T>, new()
    where TModel : class, IEntityVM<T>, new()
    where T : IEquatable<T>

{
    protected readonly IMapper _mapper;
    private readonly DbContext _dbContext;
    public DbSet<TEntity> DbSet { get; set; }
    public BaseRepository(IMapper mapper, DbContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
        DbSet = _dbContext.Set<TEntity>();
    }

    public async Task<TModel> GetById(T id)
    {
        var data = await DbSet.Where(x => x.Id.Equals(id) && !x.IsDeleted).FirstOrDefaultAsync();
        return _mapper.Map<TModel>(data);
    }

    public async Task<IEnumerable<TModel>> GetAllAsync()
    {
        return _mapper.Map<IEnumerable<TModel>>(await DbSet.Where(x => !x.IsDeleted).ToListAsync());
    }

    public async Task<List<TModel>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        var entities = await includes.Aggregate(
             DbSet.AsQueryable(), (current, include) => current.Include(include)).Where(x=>!x.IsDeleted)
             .ToListAsync().ConfigureAwait(true);

        return _mapper.Map<List<TModel>>(entities);
    }

    public async Task<TModel> InsertAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<TModel>(entity);
    }

    public async Task<TModel> UpdateAsync(T id, TEntity entity)
    {
        var data = await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(id));
        if (data != null)
        {
            entity.Copy(data);
            DbSet.Update(data);
            await _dbContext.SaveChangesAsync();
        }
        return _mapper.Map<TModel>(data);
    }

    public async Task<TModel> DeleteAsync(T id)
    {
        var data = await DbSet.FindAsync(id);
        data.IsDeleted = true;
        DbSet.Update(data);
        await _dbContext.SaveChangesAsync();
        return _mapper.Map<TModel>(data);
    }
}

