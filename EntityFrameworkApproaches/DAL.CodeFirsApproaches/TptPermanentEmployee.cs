using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.CodeFirsApproaches
{
    [Table("TptPermanentEmployees")]
    public class TptPermanentEmployee : TptEmployee
    {
        public decimal AnnualSalary { get; set; }
    }
}
