using System;
namespace SimpleCURDDotNet7.Data
{
	public class Employee : BaseEntity
	{
		public string? EmpID { get; set; }
        public string? EmpName { get; set; }
		public int EmpAge { get; set; }
		public decimal EmpSalary { get; set; }

    }
}

