using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.CodeFirsApproaches
{
    [Table("TptEmployees")]
    public class TptEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
    }
}
