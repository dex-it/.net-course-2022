using Services;
using Bogus;
using Models;
using Services;
public class Program
{
    private static void Main(string[] args)
    {
        DateTime dataTime = new DateTime(2000, 9, 23);
        Employee employee = new Employee();
        employee.Contract = UpdateContract("Lisa", "Chabah", dataTime, 2546);
       
        Currency currency = new Currency();
        currency.Name = "MDL";
        UpdateCurrency(ref currency);

        Employee owner = new Employee();
        owner.Salary = BankService.CalculateOwnerSalary(1, 2000, 1400);

        Client client = new Client();        
        var employee1 = BankService.ClientToEmployee(client); 
    }

    public static string UpdateContract(string firstName, string lastName, DateTime dateOfBirth, int seriesOfPassport)
    {
        string result = $"Имя сотрудника: {firstName} {lastName}. " +
                        $"Дата рождения: {dateOfBirth}. " +
                        $"Серия паспорта: {seriesOfPassport}";
        return result;
    }

    public static void UpdateCurrency(ref Currency currency)
    {
        currency.Name = "USD";
        currency.Code++;
    }
    
    
}
