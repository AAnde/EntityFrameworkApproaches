using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirsApproaches
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
