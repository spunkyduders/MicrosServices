using System.ComponentModel.DataAnnotations;

namespace EmpApi.Models;
public class Employee
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public byte Age { get; set; }

    [Required]
    public short Salary { get; set; }

    [Required]
    public string Dept { get; set; }
}