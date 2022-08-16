using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAndOrgUsingEF.Entities
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "integer")]
        public int Age { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Address { get; set; }
        public ICollection<EmployeeOrganizations> EmployeesOrganizations { get; set; }
    }
}

