using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirsApproaches
{
    public class CodeFirstOperations
    {
        #region EntitySplit
        public List<Employee> Esp_GetEmp()
        {
            using (var context = new Context())
            {
                var emps = context.Employees.ToList();
                return emps;
            }
        }
        public void Esp_AddEmp(Employee emp)
        {
            using (var context = new Context())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region TableSplit
        public List<EmpInfo> Tsp_GetEmp()
        {
            using (var context = new TblSplitContext())
            {

                var emp = context.EmpInfos.Include("EmpContacInformation").ToList();
              
                return emp;
            }
        }
        public void Tsp_AddEmp(EmpInfo emp)
        {
            using (var context = new TblSplitContext())
            {
                context.EmpInfos.Add(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region ConditionalMapping
        public List<CndEmployee> Cnd_GetEmp()
        {
            using (var context = new CndContext())
            {
                var emp = context.CndEmployees.ToList();
                return emp;
            }
        }
        public void Cnd_AddEmp(CndEmployee emp)
        {
            using (var context = new CndContext())
            {
                context.CndEmployees.Add(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region SelfReferencing Association
        #endregion
        #region TPH
        public List<TphEmployee> Tph_GetEmp()
        {
            using (var context = new TphContext())
            {
                var emps = context.TphEmployees.ToList();
                return emps;
            }
        }
        public void Tph_AddEmp(TphEmployee emp)
        {
            using (var context = new TphContext())
            {
                context.TphEmployees.Add(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region TPT
        public List<TptEmployee> Tpt_GetEmp()
        {
            using (var context = new TptContext())
            {
                var emps = context.TptEmployees.ToList();
                return emps;
            }
        }
        public void Tpt_AddEmp(TptContractEmployee emp)
        {
            using (var context = new TptContext())
            {
                context.TptEmployees.Add(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region ManyToMany
        public List<Student> MM_GetStudents()
        {
            using (var context = new MMContext())
            {
                var students = context.Students.Include("Courses").ToList();
                return students;
            }
        }
        public void MM_AddStudentCourse(int stdid,int crsid)
        {
            using (var context = new MMContext())
            {
                var course = context.Courses.FirstOrDefault(x => x.CourseId == crsid);
                context.Students.Include("Courses").FirstOrDefault(x => x.StudentId == stdid).Courses.Add(course);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
