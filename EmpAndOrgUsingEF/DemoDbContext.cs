using Microsoft.EntityFrameworkCore;
using EmpAndOrgUsingEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAndOrgUsingEF
{
    public class DemoDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<EmployeeOrganizations> Organizations { set; get; }
        public DemoDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0P56O06;Initial Catalog=EmpOrgEF;Integrated Security=True");
        }
    }
}
