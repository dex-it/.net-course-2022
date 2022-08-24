using BankService;
using Models;
public class Program
{
    private static void Main(string[] args)
    { 

        Employee employee = new Employee();
        employee.Contract = UpdateContract(employee);

        Currency currency = new Currency();
        currency.Name = "MDL";
        UpdateCurrency( ref currency);

        Client client = new Client();
        var client2 = Class1.ClientToEmployee(client);
    }

    public static string UpdateContract(Employee employee)
    {
        string result = $"Имя сотрудника: {employee.firstName} {employee.lastName}. Дата рождения: {employee.dateOfBirth}. Серия паспорта: {employee.seriesOfPassport}";
        return result;
    }

    public static void UpdateCurrency(ref Currency currency)
    {
        currency.Name = "USD";
        currency.code++;
    }
    
    
}
