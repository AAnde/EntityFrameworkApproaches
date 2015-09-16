using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DAL.CodeFirsApproaches
{
    public class EmpContactInfo
    {   
        public int Id { get; set; }
        public string MobileNo { get; set; }
        public string Emailid { get; set; }
        public EmpInfo EmpInfo { get; set; }
    }
}
