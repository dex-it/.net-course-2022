using Models;
public class Program
{
    static void Main()
    {
        var employee = new Employee
        {
            Name = "Alex",
            Data = new DateTime(1999, 01, 01),
            PasportNum = 372462
        };
        BadGetSampleContract(employee);
        Console.WriteLine(employee.Contract);
        employee.Contract = GetSampleContract(employee.Name, employee.Data, employee.PasportNum);
        Console.WriteLine(employee.Contract);
        var currency = new Currency
        {
            Name = "Euro"
        };
        BadGetSampleCurrency(currency);
        Console.WriteLine($"Валюта: {currency.Name}");
        currency.Name = GetSampleCurrency(currency.Name);
        Console.WriteLine(currency.Name);
    }
    static void BadGetSampleContract(Employee employee)
    {
        employee.Contract = $"Имя:  {employee.Name} Дата рождения: {employee.Data} Номер паспорта:{employee.PasportNum} ";

    }
    static string GetSampleContract(string name, DateTime date, int pasportNum)
    {
        return $"Имя: {name} Дата рождения: {date} Номер паспорта:{pasportNum} ";
    }
    static void BadGetSampleCurrency(Currency currency)
    {
        currency.Name = currency.Name;
    }
    static string GetSampleCurrency(string name)
    {
        return $"Валюта: {name}";
    }
}