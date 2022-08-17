
using EmpAndOrgUsingEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAndOrgUsingEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CRUDCustomer CDcustomer = new CRUDCustomer();
            Employee employee = new Employee { Name = "Yuvraj Singh", Age = 21, Address = "Gurgaon" };
            List<EmployeeOrganizations> employeeOrganizations = new List<EmployeeOrganizations>();
            employeeOrganizations.Add(new EmployeeOrganizations { OrgnizatinName = "IBM" });
            employeeOrganizations.Add(new EmployeeOrganizations { OrgnizatinName = "TCS" });
            employeeOrganizations.Add(new EmployeeOrganizations { OrgnizatinName = "HCL" });
            CDcustomer.InsertEmployeeWithItsOrgnization(employee, employeeOrganizations);


            CDcustomer.PrintEmployeeById(1);

            Console.WriteLine("delete 1");
            CDcustomer.DeleteEmployee(1);


            CDcustomer.PrintEmployeeById(1);

            Console.WriteLine("updateing Emp And Org");
            List<EmployeeOrganizations> updatelist = new List<EmployeeOrganizations>();
            updatelist.Add(new EmployeeOrganizations { OrgnizatinName = "Apple" });
            updatelist.Add(new EmployeeOrganizations { OrgnizatinName = "Oracle" });
            updatelist.Add(new EmployeeOrganizations { OrgnizatinName = "Kellton" });

            CDcustomer.UpdateEmployeeAndOrgnization(2, "Yuvraj Singh", updatelist);


            CDcustomer.PrintEmployeeById(2);
            CDcustomer.PrintEmployeeById(1);
            Employee newemp = new Employee { Name = "Punki", Age = 22, Address = "Gurgaon" };
            List<EmployeeOrganizations> otherwaytoinsert = new List<EmployeeOrganizations>();
            otherwaytoinsert.Add(new EmployeeOrganizations { OrgnizatinName = "Infosys", Employee = newemp });
            otherwaytoinsert.Add(new EmployeeOrganizations { OrgnizatinName = "TCS", Employee = newemp });
            CDcustomer.OtherwayToInsertEMP(otherwaytoinsert);

            CDcustomer.PrintAllEmployee();
            Console.WriteLine("done...");
            Console.ReadKey();

        }
    }

}