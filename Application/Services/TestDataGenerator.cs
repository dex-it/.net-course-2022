using Bogus;
using Bogus.DataSets;
using Models;

namespace Services;

public class TestDataGenerator
{
    
    public List<Client> GetClientCollection(int count)
    {
        var randClinet = new Faker<Client>()
            .CustomInstantiator(f => new Client())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName(f.PickRandom<Name.Gender>()))
            .RuleFor(c => c.LastName, f => f.Name.LastName(f.PickRandom<Name.Gender>()))
            .RuleFor(c => c.BirthdayDate, f => f.Date.Past(100))
            .RuleFor(c => c.PhoneNumber, f => int.Parse(f.Random.ReplaceNumbers("7#######")));
        var genClient = randClinet.Generate(count);
        return new List<Client>(genClient.ToList());
    }
    
    public Dictionary<int, Client> GetClientDictionary(List<Client> clients)
    {
        return new Dictionary<int, Client>(clients.ToDictionary(k => k.PhoneNumber, v => v));
    }
    
    public List<Employee> GetEmployeeCollection(int count)
    {
        var randEmployee = new Faker<Employee>()
            .CustomInstantiator(f => new Employee())
            .RuleFor(e => e.FirstName, f => f.Name.FirstName(f.PickRandom<Name.Gender>()))
            .RuleFor(e => e.LastName, f => f.Name.LastName(f.PickRandom<Name.Gender>()))
            .RuleFor(e => e.BirthdayDate, f => f.Date.Past(100))
            .RuleFor(e => e.PhoneNumber, f => int.Parse(f.Random.ReplaceNumbers("7#######")))
            .RuleFor(e => e.Salary, f => f.Random.Int(1000, 20000));
        var genEmployee = randEmployee.Generate(count);
        return new List<Employee>(genEmployee.ToList());
    }
}