using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace _48.CODE_FIRST_APPROCH_EF.Model
{
    internal class Employee
    {
        [Key]
       public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Designation { get; set; }
    }
}
