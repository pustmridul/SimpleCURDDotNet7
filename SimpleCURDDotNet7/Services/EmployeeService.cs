using System;
using Microsoft.EntityFrameworkCore;
using SimpleCURDDotNet7.Data;
using SimpleCURDDotNet7.Interfaces;

namespace SimpleCURDDotNet7.Services
{
	public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _dbcontextobj;

        public EmployeeService(AppDbContext context)
        {
            _dbcontextobj = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var objList = await _dbcontextobj.Employees.ToListAsync();
            return objList.AsEnumerable();
        }

        public async Task<bool> SaveEmployee(Employee model)
        {
            try
            {
                var obj = new Employee()
                {
                    EmpName = model.EmpName,
                    EmpAge = model.EmpAge,
                    EmpID = model.EmpID,
                    EmpSalary = model.EmpSalary,
                    CreateByName = model.CreateByName,
                    CreateDate = model.CreateDate
            
                };
                _dbcontextobj.Employees.Add(obj);

                await _dbcontextobj.SaveChangesAsync();
                return true;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<Employee>> GetEmployeeByName(String name)
        {
            try
            {
                var obj = await _dbcontextobj.Employees.Where(q => q.EmpName == name).ToListAsync();

                if(obj==null)
                {
                    throw new Exception();
                }
                else
                {
                    return obj;
                }
                
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

