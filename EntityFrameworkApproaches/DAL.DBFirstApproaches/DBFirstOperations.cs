using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBFirstApproaches;
using System.Data.Entity;

namespace DAL.DBFirstApproaches
{
    public class DBFirstOperations
    {
        #region EntitySplitting operations
        public List<EmployeeInfo> EntSplit_GetEmp()
        {
            using (var context = new TestDBEntities())
            {
                var emps = context.EmployeeInfoes.ToList();
                return emps;
            }
        }
        public void EntSplit_AddEmp(EmployeeInfo emp)
        {
            using (var context = new TestDBEntities())
            {
                context.EmployeeInfoes.Add(emp);
                context.SaveChanges();
            }
        }
        public void EntSplit_UpdateEmp(EmployeeInfo emp)
        {
            using (var context = new TestDBEntities())
            {
                context.Entry(emp).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void EntSplit_DeleteEmp(int id)
        {
            using (var context = new TestDBEntities())
            {
                var emp = context.EmployeeInfoes.Find(id);
                context.EmployeeInfoes.Remove(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region TableSplitting
        public List<Employee> TblSplit_GetEmp()
        {
            using (var context = new TestDBEntities())
            {
                var emps = context.Employees.Include("EmployeeContactInfo").ToList();
                return emps;
            }
        }
        public void TblSplit_AddEmp(Employee emp)
        {
            using (var context = new TestDBEntities())
            {
                context.Employees.Add(emp);
                context.SaveChanges();
            }
        }
        public void TblSplit_UpdateEmp(Employee emp)
        {
            using (var context = new TestDBEntities())
            {
                //context.Entry(emp).State = EntityState.Modified;
                var employee = context.Employees.Find(emp.Id);
                employee.Name = emp.Name;
                employee.Salary = emp.Salary;
                employee.EmployeeContactInfo.MobileNo = emp.EmployeeContactInfo.MobileNo;
                employee.EmployeeContactInfo.EmailId = emp.EmployeeContactInfo.EmailId;
                context.SaveChanges();
            }
        }
        public void TblSplit_DeleteEmp(int id)
        {
            using (var context = new TestDBEntities())
            {
                var emp = context.Employees.Find(id);
                context.EmployeeContactInfoes.Remove(emp.EmployeeContactInfo);
                context.Employees.Remove(emp);
                context.SaveChanges();
            }
        }
        #endregion
        #region Conditional Mapping
        public List<ConditionalEmployee> CndMap_GetEmp()
        {
            using (var context = new TestDBEntities())
            {
                var emps = context.ConditionalEmployees.ToList();
                return emps;
            }
        }
        #endregion
    }
}
