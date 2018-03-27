using System;
using System.Linq;

namespace WebApp.Interfaces
{
    public interface IGenericRepository<T>
        where T: class
    {
        IQueryable<T> GetAll();
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Guid id);
        void Detach(T entity);
    }
}
