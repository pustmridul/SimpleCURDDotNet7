using System;
using Microsoft.AspNetCore.Mvc;
using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.Interfaces;

namespace SimpleCURDDotNet7.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
		private readonly IEmployeeService _employeeService;
		public EmployeesController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllEmployee()
		{
			return Ok( await _employeeService.GetAllEmployees());
		}

		[HttpGet]
		public async Task<IActionResult> GetEmployeeByName(String name)
		{
			return Ok(await _employeeService.GetEmployeeByName(name));
		}

		[HttpPost]
		public async Task<IActionResult> SaveEmployee(Employee obj)
		{
			return Ok(await _employeeService.SaveEmployee(obj));
		}

	}
}

