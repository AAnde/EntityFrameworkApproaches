using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.CodeFirsApproaches
{
    public class EmpInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        [Required]
        public EmpContactInfo EmpContacInformation { get; set; }
    }
}
