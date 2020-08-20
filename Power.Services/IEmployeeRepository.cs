using Power.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Power.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee UpdatedEmployee);

      
    }
}
