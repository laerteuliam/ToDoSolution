using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Data.EF.Maps
{
    public class TodoMap : EntityTypeConfiguration<ToDoEntity>
    {
        public TodoMap()
        {
            ToTable("ToDo");
            HasKey(x => x.ID);

            Property(x => x.Descricao).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
