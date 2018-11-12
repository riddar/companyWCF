using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Company.DataAccess.Context;
using Company.Models;

namespace Company.WCF
{
	[ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
	public class CompanyService : ICompanyService, IDisposable
	{
		readonly CompanyDbContext context = new CompanyDbContext();

		public CompanyService() { }
		public void Dispose() => context.Dispose();

		public Employee CreateEmployee(Employee employee)
		{
			context.Employees.Add(employee);
			context.SaveChanges();
			return GetEmployeeById(employee.Id);
		}

		public Employee GetEmployeeById(int id)
		{
			return context.Employees.FirstOrDefault(e => e.Id == id);
		}

		public List<Employee> GetEmployees()
		{
			return context.Employees.ToList();
		}

		public void RemoveEmployee(Employee employee)
		{
			context.Employees.Remove(employee);
			context.SaveChanges();
		}

		public Employee UpdateEmployee(Employee employee)
		{
			var result = context.Employees.FirstOrDefault(e => e.Id == employee.Id);

			if (result == null)
				return null;

			result.Name = employee.Name;
			result.Salary = employee.Salary;

			return result;
		}


	}
}
