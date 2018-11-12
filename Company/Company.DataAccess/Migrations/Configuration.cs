namespace Company.DataAccess.Migrations
{
	using Company.DataAccess.Context;
	using Company.Models;
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<CompanyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CompanyDbContext context)
        {
			context.Employees.AddOrUpdate(u => u.Name,
				new Employee { Id = 1, Name = "Andersson", Salary = 50000 },
				new Employee { Id = 2, Name = "Elliot", Salary = 20000 },
				new Employee { Id = 3, Name = "Smith", Salary = 15000 },
				new Employee { Id = 4, Name = "blob", Salary = 30000 }
			);
		}
    }
}
