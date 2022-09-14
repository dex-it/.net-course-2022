using Models;

namespace Services.Storages;

public class EmployeeStorage : IEmployeeStorage
{
    public List<Employee> Data { get; }

    public EmployeeStorage()
    {
        Data = new List<Employee>();
    }

    public void Add(Employee employee)
    {
        Data.Add(employee);
    }

    public void Update(Employee employee)
    {
    }

    public void Delete(Employee employee)
    {
        Data.RemoveAll(emp => emp.Equals(employee));
    }
}