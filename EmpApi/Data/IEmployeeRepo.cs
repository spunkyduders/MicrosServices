using EmpApi.Models;

namespace EmpApi.Data;

public interface IEmployeeRepo
{
    IEnumerable<Employee> GetEmployees();
    Employee GetEmployeeById(int empId);
    bool DeleteEmployee(int empId);
    Employee? AddEmployee(Employee emp);
    int SaveChanges();
}

