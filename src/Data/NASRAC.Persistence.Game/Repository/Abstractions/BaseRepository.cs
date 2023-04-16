using System.Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using NASRAC.Persistence.Game.DAL;

namespace NASRAC.Persistence.Game.Repository;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly DataContext DataContext;
    protected readonly DbSet<T> Repository;
    
    protected BaseRepository(DataContext dataContext)
    {
        DataContext = dataContext;
        Repository = dataContext.Set<T>();
    }
    
    public T GetById(int id)
    {
        return DataContext.Set<T>().Find(id) ?? throw new ObjectNotFoundException();
    }

    public IEnumerable<T> GetAll()
    {
        return DataContext.Set<T>();
    }

    public void Add(T entity)
    {
        DataContext.Set<T>().Add(entity);
        DataContext.SaveChanges();
    }

    public void Update(T entity)
    {
        DataContext.Set<T>().Update(entity);
        DataContext.SaveChanges();
    }

    public void Delete(T entity)
    {
        DataContext.Set<T>().Remove(entity);
        DataContext.SaveChanges();
    }
}