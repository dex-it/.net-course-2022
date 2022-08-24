namespace Models
{
    public class Person
    {
        public string? name;
        public int? age;
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Print() => Console.WriteLine($"Name: {name} - {age}");
    }
    public class Employee : Person
    {
        public string contract;
        public Employee(string name, int age) : base(name, age)
        { }
        public Employee(string name, int age, string contract) : base(name, age)
        {
            this.contract = contract;
        }
    }

    public class Client : Person
    {
        public Client(string name, int age) : base(name, age)
        {
        }
    }
    public struct Currency
    {
        public string currency;
        public double price;
    }
}