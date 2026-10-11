using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48.CODE_FIRST_APPROCH_EF.Model
{
    internal class DatabaseContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
