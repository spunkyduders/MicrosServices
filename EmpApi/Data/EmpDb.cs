using EmpApi.Models;
using Microsoft.EntityFrameworkCore;
namespace EmpApi.Data;

public static class EmpDb
{
    public static void Seed(WebApplication app, bool isProd)
    {
        using (var svcScope = app.Services.CreateScope())
        {
            var context = svcScope.ServiceProvider.GetService<EmployeeDbContext>();
            Populate(context, isProd);
        }
    }

    private static void Populate(EmployeeDbContext context, bool isProd)
    {
        // if (isProd)
        context.Database.Migrate();
        // else
        // {
        //     context.Employees.AddRange(
        //         new Employee() { Id = 1, Name = "Raj", Age = 28, Salary = 2322, Dept = "HR" },
        //         new Employee() { Id = 2, Name = "Sekhar", Age = 38, Salary = 4322, Dept = "Engg" },
        //         new Employee() { Id = 3, Name = "Bat", Age = 48, Salary = 4322, Dept = "IT" }
        //     );
        //     context.SaveChanges();
        // }


    }
}