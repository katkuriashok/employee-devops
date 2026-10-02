using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _employeeService;

    public EmployeesController(EmployeeService employeeService) => _employeeService = employeeService;

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetAll() => Ok(_employeeService.GetAll());

    [HttpGet("{id:int}")]
    public ActionResult<Employee> GetById(int id)
    {
        var employee = _employeeService.GetById(id);
        return employee is null ? NotFound() : Ok(employee);
    }

    [HttpPost]
    public ActionResult<Employee> Create(Employee employee)
    {
        var created = _employeeService.Add(employee);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Employee employee) =>
        _employeeService.Update(id, employee) ? NoContent() : NotFound();

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id) =>
        _employeeService.Delete(id) ? NoContent() : NotFound();
}
