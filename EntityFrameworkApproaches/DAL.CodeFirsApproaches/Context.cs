using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class Context:DbContext
    {
        public Context() : base("name=DBEntities") 
        { }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Map(
                map =>
                {
                    map.Properties(p => new { p.Name, p.Salary });
                    map.ToTable("Employees");
                })
                .Map(
                map =>
                {
                    map.Properties(p => new { p.MobileNo, p.EmailId });
                    map.ToTable("EmployeeContactDetails");
                });
                
            base.OnModelCreating(modelBuilder);
        }
       
    }
}
