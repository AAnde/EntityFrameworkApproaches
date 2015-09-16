using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class TphContext:DbContext
    {
        public TphContext() : base("name=DBEntities") { }
        public DbSet<TphEmployee> TphEmployees { get; set; }
    }
}
