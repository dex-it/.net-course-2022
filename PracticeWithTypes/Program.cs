using Models;
using Services;
public class Program
{
    static void Main()
    {
        var bankService = new BankService();
        Console.WriteLine($"Расчет ЗП владельцев банка: {bankService.SalaryOwnerOfBank(50000, 30000, 2)}");
        var client = new Client
        {
            Name = "Alex",
            BirtDate = new DateTime(1999, 01, 01),
            PasportNum = 372462
        };
        var employee = new Employee();
        employee = bankService.ClientInEmployee(client);
        Console.WriteLine($"Перевод клиента в работника" + 
            $"\nИмя: {employee.Name} Дата рождения: {employee.BirtDate} Номер паспорта:{employee.PasportNum}" +
            $"Зарплата: {employee.Salary}");

    }
}