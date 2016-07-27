using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories.Core
{
    public interface IRepository<T> 
        where T : class
    {
        void AddOrUpdate(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Delete(int id);
    }
}
