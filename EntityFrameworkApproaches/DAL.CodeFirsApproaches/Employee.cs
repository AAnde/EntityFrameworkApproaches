using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.CodeFirsApproaches
{
    public class Employee
    {
        //These properties should mapped to Employee table
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        //These properties should mapped to EmployeeContact details
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    }
}
