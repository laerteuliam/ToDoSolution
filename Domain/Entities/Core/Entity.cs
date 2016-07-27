using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Core
{
    public abstract class Entity<T>
    {
        public T ID { get; set; }
    }
}
