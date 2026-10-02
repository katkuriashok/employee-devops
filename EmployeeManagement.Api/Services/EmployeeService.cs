using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Services;

public class EmployeeService
{
    private readonly List<Employee> _employees = new()
    {
        new Employee { Id = 1, Name = "Ashok", Department = "DevOps", Email = "ashok@example.com" },
        new Employee { Id = 2, Name = "Rahul", Department = "Development", Email = "rahul@example.com" }
    };

    public IEnumerable<Employee> GetAll() => _employees;

    public Employee? GetById(int id) => _employees.FirstOrDefault(x => x.Id == id);

    public Employee Add(Employee employee)
    {
        employee.Id = _employees.Count == 0 ? 1 : _employees.Max(x => x.Id) + 1;
        _employees.Add(employee);
        return employee;
    }

    public bool Update(int id, Employee employee)
    {
        var existing = GetById(id);
        if (existing is null) return false;

        existing.Name = employee.Name;
        existing.Department = employee.Department;
        existing.Email = employee.Email;
        return true;
    }

    public bool Delete(int id)
    {
        var employee = GetById(id);
        return employee is not null && _employees.Remove(employee);
    }
}
