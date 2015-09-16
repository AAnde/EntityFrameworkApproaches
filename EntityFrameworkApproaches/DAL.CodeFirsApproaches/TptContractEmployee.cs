using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.CodeFirsApproaches
{
    [Table("TptContractEmployees")]
    public class TptContractEmployee : TptEmployee
    {
        public decimal HourPay { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
