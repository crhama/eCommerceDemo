using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using WebApp.Data;
using WebApp.Interfaces;

namespace WebApp.Repositories
{
    public class GenericRepository<T>
        : IGenericRepository<T> where T : class
    {
        public DbSet<T> DBSet { get; set; }
        public EShoperDbContext Context { get; set; }

        public GenericRepository(EShoperDbContext Context)
        {
            if (Context == null)
                throw new ArgumentNullException("An instance of DbContext is required to use this repository");

            DBSet = Context.Set<T>();
        }

        public void Add(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if(entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DBSet.Add(entity);
            }
        }

        public void Delete(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                DBSet.Attach(entity);
                DBSet.Remove(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            if(entity != null)
            {
                Delete(entity);
            }
        }

        public void Detach(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        public IQueryable<T> GetAll()
        {
            return DBSet;
        }

        public T GetById(Guid id)
        {
            return DBSet.Find(id);
        }

        public void Update(T entity)
        {
            EntityEntry entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                this.DBSet.Add(entity);
            }
            entry.State = EntityState.Modified;
        }
    }
}
