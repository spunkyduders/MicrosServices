using AutoMapper;
using EmpApi.Data;
using EmpApi.Dtos;
using EmpApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpApi.Controllers;

[ApiController]
[Route("{controller}")]
public class EmployeeController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepo _repo;

    public EmployeeController(IMapper mapper, IEmployeeRepo repo)
    {
        _mapper = mapper;
        _repo = repo;
    }
    [HttpGet]
    public ActionResult<IEnumerable<EmployeeReadDto>> GetEmployees()
    {
        var employees = _repo.GetEmployees();
        return Ok(_mapper.Map<IEnumerable<EmployeeReadDto>>(employees));
    }

    [HttpGet("{Id}")]
    public ActionResult<EmployeeReadDto> GetEmployeeById(int id)
    {
        var employee = _repo.GetEmployeeById(id);
        return Ok(_mapper.Map<EmployeeReadDto>(employee));
    }

    [HttpPost]
    public ActionResult<EmployeeReadDto> AddEmployee(EmployeeCreateDto emp)
    {
        var empModel = _mapper.Map<Employee>(emp);
        var employee = _repo.AddEmployee(empModel);
        return Ok(_mapper.Map<EmployeeReadDto>(employee));
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteEmployee(int id)
    {
        var isDeleted = _repo.DeleteEmployee(id);

        return Ok($"Employee record with ID {id} is deleted from the DB.");
    }
}
