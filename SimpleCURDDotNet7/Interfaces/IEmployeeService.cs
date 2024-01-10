using System;
using SimpleCURDDotNet7.Data;

namespace SimpleCURDDotNet7.Interfaces
{
	public interface IEmployeeService
	{
        Task<bool> SaveEmployee(Employee model);
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<List<Employee>> GetEmployeeByName(String name);

    }
}

