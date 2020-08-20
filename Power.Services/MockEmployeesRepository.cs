using Power.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Power.Services
{
    public class MockEmployeesRepository : IEmployeeRepository
    {
        private List<Employee> employeesList;

        public MockEmployeesRepository()
        {
            employeesList = new List<Employee>()
            {
                new Employee()
                {
                 id=0, name="Marry", Email="Marry1998@example.com",PhotoPath="avatar2.png",Departman=Dept.HR
                },
                new Employee()
                {
                    id = 1, name = "Ivan", Email = "Vanya@example.com", PhotoPath = "avatar3.png", Departman = Dept.IT
                },
                new Employee()
                {
                    id = 2, name = "Dima", Email = "Dmitriy@example.com", PhotoPath = "avatar4.png", Departman = Dept.Payroll
                },

            };
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employeesList;
        }

        public Employee GetEmployee(int id)
        {
            return employeesList.FirstOrDefault(x => x.id == id);
        }

        public Employee Update(Employee UpdatedEmployee)
        {
            Employee employee = employeesList.FirstOrDefault(x => x.id == UpdatedEmployee.id);

            if(employee != null)
            {
                employee.name = UpdatedEmployee.name;
                employee.Email= UpdatedEmployee.Email;
                employee.Departman = UpdatedEmployee.Departman;
                employee.PhotoPath = UpdatedEmployee.PhotoPath;
            }
            return employee;
        }
    }
}
