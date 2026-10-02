using EmployeeManagement.Api.Models;
using EmployeeManagement.Api.Services;

namespace EmployeeManagement.Tests;

public class EmployeeServiceTests
{
    [Fact]
    public void GetAll_ShouldReturnEmployees()
    {
        var service = new EmployeeService();
        Assert.NotEmpty(service.GetAll());
    }

    [Fact]
    public void GetById_ShouldReturnEmployee()
    {
        var service = new EmployeeService();
        var employee = service.GetById(1);
        Assert.NotNull(employee);
        Assert.Equal("Ashok", employee.Name);
    }

    [Fact]
    public void Add_ShouldCreateEmployee()
    {
        var service = new EmployeeService();
        var employee = service.Add(new Employee
        {
            Name = "Test User",
            Department = "DevOps",
            Email = "test@example.com"
        });
        Assert.True(employee.Id > 0);
        Assert.Equal("Test User", employee.Name);
    }

    [Fact]
    public void Update_ShouldModifyEmployee()
    {
        var service = new EmployeeService();
        var updated = service.Update(1, new Employee
        {
            Name = "Ashok Updated",
            Department = "Cloud",
            Email = "updated@example.com"
        });
        Assert.True(updated);
        Assert.Equal("Ashok Updated", service.GetById(1)!.Name);
    }

    [Fact]
    public void Delete_ShouldRemoveEmployee()
    {
        var service = new EmployeeService();
        Assert.True(service.Delete(1));
        Assert.Null(service.GetById(1));
    }
}
