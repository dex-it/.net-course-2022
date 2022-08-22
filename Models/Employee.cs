namespace Models;

public class Employee:Person
{
    public string Contract { get; set; }
    public Employee(string name, int passport, string phone, DateTime birthday) : base(name, passport, phone, birthday)
    {
    }
}