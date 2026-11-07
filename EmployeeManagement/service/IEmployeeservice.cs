using System;
using EmployeeManagement.Models;

namespace EmployeeManagement.Interfaces;

public interface IEmployeeservice
{
    Task<List<Employee>> GetAllEmployees();
    Employee GetEmployeeById(int id);
    Employee AddEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    Employee DeleteEmployee(int id);

}
