using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;
using EmployeeManagement.Interfaces;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;
using Microsoft.AspNetCore.Mvc;



namespace EmployeeManagement.service
{
    public class Employeeservice : IEmployeeservice
    {
        private readonly EmployeeManagementContext _context;

        public Employeeservice(EmployeeManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.Find(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChangesAsync();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingEmployee = _context.Employees.Find(employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Department = employee.Department;
                existingEmployee.Salary = employee.Salary;
                existingEmployee.JoiningDate = employee.JoiningDate;
                _context.SaveChanges();
            }
            return existingEmployee;
        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

       

    }
}
