using EmpApi.Dtos;
using EmpApi.Models;

namespace EmpApi.Data;

public class EmployeeRepo : IEmployeeRepo
{
    private EmployeeDbContext _repository;

    public EmployeeRepo(EmployeeDbContext repository)
    {
        _repository = repository;
    }

    public Employee? AddEmployee(Employee emp)
    {
        if (emp == null)
            throw new ArgumentNullException("Employee");

        var res = _repository.Add(emp);
        if (res != null)
        {
            _repository.SaveChanges();
            return emp;
        }
        return null;
    }

    public bool DeleteEmployee(int empId)
    {
        var emp = _repository.Employees.FirstOrDefault(p => p.Id == empId);

        if (emp != null)
        {
            _repository.Employees.Remove(emp);
            _repository.SaveChanges();
            return true;
        }
        return false;

    }

    public Employee GetEmployeeById(int empId)
    {
        var emp = _repository.Employees.FirstOrDefault(p => p.Id == empId);
        return emp != null ? emp : throw new ArgumentNullException($"EmpId:{empId}");
    }

    public IEnumerable<Employee> GetEmployees()
    {
        return _repository.Employees;
    }

    public int SaveChanges()
    {
        return _repository.SaveChanges();
    }


}