using Models;
public class Program
{
    static void Main()
    {
        Employee employee1 = new Employee("Alex", new DateTime(1999, 01, 01), 372462);
        //Console.WriteLine(SampleContract(employee1));
        Console.WriteLine(employee1.Contract = SampleContract1(employee1.name, employee1.Data, employee1.NumPasport));
        Currency currency1 = new Currency("Euro");
        //Console.WriteLine(SampleCurrency(currency1)); 
        Console.WriteLine(currency1.NameCurrency = SampleCurrency1(currency1.NameCurrency));
    }
    //static void SampleContract(Employee employee)
    //{
    //    employee.Contract = $"Имя:  {employee.name} Дата рождения: {employee.Data} Номер паспорта:{employee.NumPasport} ";

    //}
    static string SampleContract1(string name, DateTime date, int numPasport)
    {
        return $"Имя: {name} Дата рождения: {date} Номер паспорта:{numPasport} ";
    }
    //static void SampleCurrency(Currency currency)
    //{
    //    currency.NameCurrency = $"Валюта: {currency.NameCurrency}";
    //}
    static string SampleCurrency1(string name)
    {
        return $"Валюта: {name}";
    }
}