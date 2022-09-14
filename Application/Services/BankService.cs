using Models;

namespace Services;

public class BankService
{
    private List<Person> _blackList { get; }

    public BankService()
    {
        _blackList = new List<Person>();
    }
    
    public T AddBonus<T>(T person) where T: Person
    {
        person.Bonus += 1;
        return person;
    }
    
    public void AddToBlackList<T>(T person) where T: Person
    {
        _blackList.Add(person);
    }
    public bool IsPersonInBlackList<T>(T person) where T: Person
    {
        return _blackList.Contains(person);
    }
}