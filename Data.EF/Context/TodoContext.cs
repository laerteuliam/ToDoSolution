using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domain.Entities;

namespace Data.EF.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext()
            : base("ToDoDBConnection")
        {
            Database.SetInitializer<TodoContext>(null);

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<ToDoEntity> ToDoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new Maps.TodoMap());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
