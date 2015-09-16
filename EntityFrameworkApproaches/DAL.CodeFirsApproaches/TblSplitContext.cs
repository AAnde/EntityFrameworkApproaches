using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class TblSplitContext:DbContext
    {
        public TblSplitContext() : base("name=DBEntities") { }
        public DbSet<EmpInfo> EmpInfos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpInfo>()
                .HasKey(pk => pk.Id)
                .ToTable("EmpInfos");
            modelBuilder.Entity<EmpContactInfo>()
                .HasKey(pk => pk.Id)
                .ToTable("EmpInfos");
            modelBuilder.Entity<EmpInfo>()
                .HasRequired(p => p.EmpContacInformation)
                .WithRequiredPrincipal(c => c.EmpInfo);
            base.OnModelCreating(modelBuilder);
        }
    }
}
