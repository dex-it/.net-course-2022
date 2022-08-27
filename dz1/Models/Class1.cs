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
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class Employee : Person
    {

        public string Contract { get; set; }
        public Currency Curr { get; set; } = new Currency();

        
     
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
        public EnumCur Cur { get; set; }
        public int Salary { get; set; }
    }
}