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
    }
}
