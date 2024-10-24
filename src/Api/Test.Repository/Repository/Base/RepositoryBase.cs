using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Contracts;

namespace Test.Repository.Repository.Base;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected TestDbContext db;
    public RepositoryBase(TestDbContext _db) => db = _db;
    public void Create(T entity)
    {
        db.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        db.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindAll(bool trackChanges)
    {
        if (trackChanges)
        {
            return db.Set<T>();
        }
        else
        {
            return db.Set<T>().AsNoTracking();
        }
    }
  
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
    {
        if (trackChanges)
        {
            return db.Set<T>().Where(expression);
        }
        else
        {
            return db.Set<T>().Where(expression).AsNoTracking();
        }
    }

    public void Update(T entity)
    {
        db.Set<T>().Update(entity);
    }
}
