using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ToDoEntity : Core.Entity<int>
    {
        public string Descricao { get; set; }
        public VO.TodoStatusVO Status { get; set; }
    }
}
