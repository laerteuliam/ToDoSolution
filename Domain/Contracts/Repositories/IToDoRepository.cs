using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.Repositories
{
    public interface IToDoRepository : Core.IRepository<Entities.ToDoEntity>
    {
    }
}
