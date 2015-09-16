using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class CndContext:DbContext
    {
        public CndContext() : base("name=DBEntities") { }
        public DbSet<CndEmployee> CndEmployees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CndEmployee>()
                .Map(m => m.Requires("IsTerminated").HasValue(false)).Ignore(m => m.IsTerminated);
            base.OnModelCreating(modelBuilder);
        }
    }
}
