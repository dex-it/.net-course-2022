using Models;
public class Program
{
    static void Main()
    {
        var employee = new Employee
        {
            Name = "Alex",
            Data = new DateTime(1999, 01, 01),
            NumPasport = 372462
        };
        //Console.WriteLine(SampleContract(employee));
        Console.WriteLine(employee.Contract = SampleContract1(employee.Name, employee.Data, employee.NumPasport));
        var currency = new Currency
        {
            NameCurrency = "Euro"
        };
        //Console.WriteLine(SampleCurrency(currency)); 
        Console.WriteLine(currency.NameCurrency = SampleCurrency1(currency.NameCurrency));
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