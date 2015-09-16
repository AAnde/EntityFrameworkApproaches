using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CodeFirsApproaches
{
    public class TphContractEmployee : TphEmployee
    {
        public decimal HourPay { get; set; }
        public decimal HoursWorked { get; set; }
    }
}
