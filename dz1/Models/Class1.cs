namespace Models
{
    /*
     а) метод, обновляющий контракт сотрудника. Принимает на вход
  сотрудника и создает контракт (свойство класса “Employee”, строка) на
  основе его данных. Результат присваивается обратно в тело сотрудника,
  свойству “Contract”;
  б) метод обновляющий сущность валюты. (Метод принимает на вход
  экземпляр структуры “Currency”, меняет значение ее свойств);
  */

    

    public class Person
    {
        
        public string Name { get; private set; }
        public int Age { get; private set; }

        
        public Person()
        {
            Name = "";
            Age = 12;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

       
    }

    public class Employee : Person
    {
        //Свойства/свойства 
        public string Contract { get; private set; } = "Нет контракта";
        public Currency Curr { get; private set; } = new Currency();

        //Конструктор`ы
        public Employee()
        {
        }
        public Employee(string name, int age) : base(name, age)
        {
            
        }

        //Методы
        public void ChangeContracts()
        {
            if (Name.Length < 2)
            {
                Console.WriteLine("Имя слишком короткое");
                return;
            }
            if (Age < 14)
            {
                Console.WriteLine("По ТК ПМР нельзя работать людям младше 14 лет");
                return;
            }
            Contract = $"Contract: {Name} - {Age} - {Curr.Cur} - { (Curr.Salary == 0 ? "волонтёр" : Curr.Salary) }";
        }
        public void ChangeCurrency(Currency cur)
        {
            Curr = cur;
        }
        public void ShowEmployee()
        {
            Console.WriteLine($"Name: {Name}\r\nAge: {Age}\r\nContract: \"{Contract}\"\r\nCurrency: {Curr.Cur}\r\nSalary: {Curr.Salary}");
        }
    }

    public class Client : Person
    {

    }

    public enum EnumCur { RUB, USD, EUR, UAH }
    public struct Currency
    {
        //Свойства
        public EnumCur Cur { get; set; }
        public int Salary { get; set; }

        //Конструктор`ы
        public Currency()
        {
            Cur = EnumCur.UAH;
            Salary = 0;
        }
        public Currency(EnumCur cur)
        {
            Cur = cur;
            Salary = 0;
        }
        public Currency(EnumCur cur, int salary)
        {
            Cur = cur;
            Salary = salary;
        }
    }
}