using AutoMapper;
using EmpApi.Dtos;
using EmpApi.Models;

namespace EmpApi.Profiles;

public class EmpProfile : Profile
{
    public EmpProfile()
    {
        CreateMap<Employee, EmployeeReadDto>();
        CreateMap<EmployeeReadDto, Employee>();
        CreateMap<EmployeeCreateDto, Employee>();
    }
}