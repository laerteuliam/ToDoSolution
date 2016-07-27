using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Core;
using Domain.Contracts.Repositories.Core;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Data.EF.Repositories.Core
{
    public class Repository<T> : IRepository<T>
        where T : Entity<int>
    {
        protected DbContext _context { get; set; }
        protected DbSet<T> _dbSet { get; set; }

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int ID)
        {
            return _dbSet.Find(ID);
        }
        
        public void AddOrUpdate(T entity)
        {
            if(entity.ID==0)
                _dbSet.Add(entity);
            else
            {
                var original = _dbSet.Find(entity.ID);
                _context.Entry(original).CurrentValues.SetValues(entity);
            }

            _context.SaveChanges();
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
