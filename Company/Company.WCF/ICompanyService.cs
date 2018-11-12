using Company.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Company.WCF
{
	[ServiceContract]
	public interface ICompanyService
	{
		[OperationContract]
		List<Employee> GetEmployees();
		[OperationContract]
		Employee GetEmployeeById(int id);
		[OperationContract]
		Employee UpdateEmployee(Employee employee);
		[OperationContract]
		void RemoveEmployee(Employee employee);
		[OperationContract]
		Employee CreateEmployee(Employee employee);
	}
}
