using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Data;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;
using EmployeeManagement.Interfaces;
using EmployeeManagement.service;


namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly EmployeeManagementContext _context;
        public EmployeesController(EmployeeManagementContext context)
        {
            _context = context;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IActionResult> GetAllGetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }           

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }   
        

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult>     Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
        }
    }
}
