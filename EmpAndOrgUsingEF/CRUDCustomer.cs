using EmpAndOrgUsingEF.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpAndOrgUsingEF
{
    public class CRUDCustomer
    {
        DemoDbContext DbContextobj;
        public CRUDCustomer()
        {
            DbContextobj = new DemoDbContext();
        }
        public void InsertEmployeeWithItsOrgnization(Employee employee, List<EmployeeOrganizations> employeeOrganizationsList)
        {
            var Employee = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                EmployeesOrganizations = employeeOrganizationsList
            };
            DbContextobj.Add(Employee);
            DbContextobj.SaveChanges();


        }
        public void PrintEmployeeById(int id)
        {
            var emp = DbContextobj.Employees.Where(empl => empl.Id == id).Include(e => e.EmployeesOrganizations).FirstOrDefault();
            if (emp != null)
            {
                Console.WriteLine("Employe Name   :" + emp.Name);
                Console.WriteLine("Employee Age   :" + emp.Age);
                Console.WriteLine("Employee Address:" + emp.Address);
                Console.WriteLine();
                foreach (EmployeeOrganizations employeeOrganizations in emp.EmployeesOrganizations)
                {
                    Console.WriteLine("Employee Organization  :" + employeeOrganizations.OrgnizatinName);
                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :" + id);
            }
        }


        public void PrintAllEmployee()
        {
            var empl = DbContextobj.Employees.Include(e => e.EmployeesOrganizations).ToList();
            if (empl != null)
            {
                foreach (Employee emp in empl)
                {
                    Console.WriteLine("Employe Name   :" + emp.Name);
                    Console.WriteLine("Employee Age   :" + emp.Age);
                    Console.WriteLine("Employee Address:" + emp.Address);
                    Console.WriteLine();
                    foreach (EmployeeOrganizations employeeOrganizations in emp.EmployeesOrganizations)
                    {
                        Console.WriteLine("Employee Organization  :" + employeeOrganizations.OrgnizatinName);
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :");
            }
        }


        public void DeleteEmployee(int empId)
        {
            var delEmp = DbContextobj.Employees.Where(emp => emp.Id == empId).Include(e => e.EmployeesOrganizations).First();
            if (delEmp != null)
            {
                DbContextobj.Employees.Remove(delEmp);
                delEmp.EmployeesOrganizations.Clear();
                DbContextobj.SaveChanges();
            }
            else
            {
                Console.WriteLine("No Record Found With This Id : " + empId);
            }
        }

        public void UpdateEmployeeAndOrgnization(int empId, string empname, List<EmployeeOrganizations> UpdateList)
        {
            var updateemp = DbContextobj.Employees.Where(emp => emp.Id == empId).Include(e => e.EmployeesOrganizations).First();
            if (updateemp != null)
            {
                updateemp.Name = empname;
                updateemp.EmployeesOrganizations = UpdateList;
                DbContextobj.Employees.Update(updateemp);
                DbContextobj.SaveChanges();
            }
            else
            {
                Console.WriteLine(" No Record Exist With This Id " + empId);
            }

        }
        public void OtherwayToInsertEMP(List<EmployeeOrganizations> orgainizationsList)
        {
            DbContextobj.Organizations.AddRange(orgainizationsList);
            DbContextobj.SaveChanges();
            Console.WriteLine("added");

        }
    }
}
