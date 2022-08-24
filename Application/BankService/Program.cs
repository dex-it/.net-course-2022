using Models;

namespace BankService;

class Program
{
    static void Main(string[] args)
    {
        Employee firstOwner = new Employee
        {
            FirstName = "Иван", LastName = "Иванов", BirthdayDate = new DateTime(1980, 5, 10), PhoneNumber = 077766699
        };
        Employee secondOwner = new Employee
        {
            FirstName = "Петр", LastName = "Петров", BirthdayDate = new DateTime(1975, 3, 21), PhoneNumber = 077854357
        };
        double bankProfit = 288000.55;
        double bankExpenses = 145000.33;

        int ownersSalary = GetOwnersSalary(bankProfit, bankExpenses, firstOwner, secondOwner);
        firstOwner.Salary = ownersSalary;
        secondOwner.Salary = ownersSalary;

        Client client = new Client
        {
            FirstName = "Федор", LastName = "Федоров", PhoneNumber = 077760235, BirthdayDate = new DateTime(1999, 05, 10) 
        };
        Employee employee = ClientToEmployee(client);
    }

    static int GetOwnersSalary(double bankProfit, double bankExpenses, params Employee[] owners)
    {
        return (int)((bankProfit - bankExpenses) / owners.Length);
    }

    static Employee ClientToEmployee(Client client)
    {
        Person person = client;
        Employee? employee = person as Employee; // null

        // преоброазование невозможно
        
        Employee employee2 = new Employee
        {
            FirstName =  client.FirstName, LastName = client.LastName, BirthdayDate = client.BirthdayDate, PhoneNumber = client.PhoneNumber
        };
        return employee2;
    }
}