using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]

    public class EmployeesController : ControllerBase
    {
        private readonly MyApplicationDbContext _context;
        public EmployeesController(MyApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("api/Employees")]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpGet]
        [Route("api/Employee/{id}")]
        public IActionResult GetEmployees(int id)
        {
            var employee = _context.Employees.Find(id);
            return Ok(employee);
        }

        [HttpPost]
        [Route("api/Employee/create")]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                var message = new { Message = "Successfully Created" };
                return Created("", message);
            }
            return BadRequest(employee);
        }
    }
}