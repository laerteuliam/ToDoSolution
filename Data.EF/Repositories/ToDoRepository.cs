using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Contracts.Repositories;
using System.Data.Entity;

namespace Data.EF.Repositories
{
    public class ToDoRepository : Core.Repository<ToDoEntity>, IToDoRepository
    {
        public ToDoRepository(DbContext context) : base(context)
        {
        }
    }
}
