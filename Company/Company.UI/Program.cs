using Company.Models;
using Company.UI.CompanyService;
using System;

namespace Company.UI
{
	public class Program
	{

		static void Main(string[] args)
		{
			Menu();
		}

		public static void Menu()
		{
			Console.Clear();
			Console.WriteLine("---------------------------");
			Console.WriteLine("|        CompanyDb        |");
			Console.WriteLine("|  1. Add Employee        |");
			Console.WriteLine("|  2. Get all Employees   |");
			Console.WriteLine("|  3. Update Employee     |");
			Console.WriteLine("|  4. Remove Employee     |");
			Console.WriteLine("|  5. Quit                |");
			Console.WriteLine("---------------------------");

			try
			{
				bool KeepGoing = true;
				do
				{
					switch (Console.ReadKey(true).Key)
					{
						case ConsoleKey.D1:
							AddEmployee();
							break;
						case ConsoleKey.D2:
							GetAllEmployees();
							break;
						case ConsoleKey.D3:
							ChangeEmployee();
							break;
						case ConsoleKey.D4:
							RemoveEmployee();
							break;
						case ConsoleKey.D5:
							KeepGoing = false;
							break;
						default:
							break;
					}
				} while (KeepGoing != false);

			}
			catch (Exception e) { Console.WriteLine(e); }
		}

		public static void AddEmployee()
		{
			Console.Write("Please enter a name: ");
			string name = Console.ReadLine();
			Console.Write("Please enter a salary: ");
			decimal salary = decimal.Parse(Console.ReadLine());

			using (var context = new CompanyServiceClient())
			{
				Employee employee = context.CreateEmployee(new Employee() { Name = name, Salary = salary });
				Console.WriteLine($"{employee.Name}, {employee.Salary}");
			}

			Menu();
		}

		public static void GetAllEmployees()
		{
			using (var context = new CompanyServiceClient())
			{
				var employees = context.GetEmployees();
				foreach (var employee in employees)
				{
					Console.WriteLine($"{employee.Id}, {employee.Name}, {employee.Salary}");
				}
			}
			Console.ReadKey();
			Menu();
		}

		public static void ChangeEmployee()
		{
			Console.Write("What is the Id: ");
			int id = int.Parse(Console.ReadLine());
			Console.Write("What name would you like: ");
			string name = Console.ReadLine();
			Console.Write("What Salary would you like: ");
			decimal salary = decimal.Parse(Console.ReadLine());

			using (var context = new CompanyServiceClient())
			{
				var employee = context.UpdateEmployee(new Employee { Id=id, Name=name, Salary=salary });
				if (employee == null)
					Console.WriteLine("couldnt find employee");
			}
			Menu();
		}

		public static void RemoveEmployee()
		{
			Console.Write("What is the Id: ");
			int id = int.Parse(Console.ReadLine());

			using (var context = new CompanyServiceClient())
			{
				Employee employee = context.GetEmployeeById(id);

				if(employee == null)
					Console.WriteLine("couldnt find employee");
				else
					context.RemoveEmployee(employee);
			}
			Menu();
		}
	}
}
