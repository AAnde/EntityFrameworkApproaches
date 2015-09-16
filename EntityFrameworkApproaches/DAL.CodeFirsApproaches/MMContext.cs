using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.CodeFirsApproaches
{
    public class MMContext : DbContext
    {
        public MMContext() : base("name=DBEntities") { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(t => t.Courses)
                .WithMany(t => t.Students)
                .Map(map =>
                {
                    map.ToTable("StudentCourses");
                    map.MapLeftKey("StudentId");
                    map.MapRightKey("CourseId");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
