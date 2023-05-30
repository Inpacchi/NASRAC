using System.Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game.Repository.Abstractions;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DataContext _dataContext;
    protected readonly DbSet<T> Repository;
    
    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
        Repository = dataContext.Set<T>();
    }
    
    public T GetById(int id)
    {
        return _dataContext.Set<T>().Find(id) ?? throw new ObjectNotFoundException();
    }

    public IEnumerable<T> GetAll()
    {
        return _dataContext.Set<T>();
    }

    public void Add(T entity)
    {
        _dataContext.Set<T>().Add(entity);
        _dataContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _dataContext.Set<T>().Update(entity);
        _dataContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        _dataContext.Set<T>().Remove(entity);
        _dataContext.SaveChanges();
    }
}