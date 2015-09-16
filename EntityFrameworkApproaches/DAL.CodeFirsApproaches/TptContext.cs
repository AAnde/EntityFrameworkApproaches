using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class TptContext:DbContext
    {
        public TptContext() : base("name=DBEntities") { }
        public DbSet<TptEmployee> TptEmployees { get; set; }
    }
}
