using System.Diagnostics;

namespace Services;

class Program
{
    static void Main(string[] args)
    {
        var dataGenerators = new TestDataGenerator();
        var clientCollection = dataGenerators.GetClientList(1000);
        var clientDictionary = dataGenerators.GetClientDictionary(clientCollection);
        var employeeCollection = dataGenerators.GetEmployeeList(1000);
        var lastClientPhoneNumber = clientCollection.Last().PhoneNumber;
        var sw = new Stopwatch();

        var maxItteration = 3;
        
        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getLastClientFromCollection  = clientCollection.FirstOrDefault(c => c.PhoneNumber == lastClientPhoneNumber);
            sw.Stop();
            Console.WriteLine($"{i + 1}. Поиск клиента по его номеру телефона, среди элементов коллекции: {sw.ElapsedTicks} тиков");
            sw.Reset();
        }
        Console.WriteLine();

        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getLastClientFromDictionary = clientDictionary[lastClientPhoneNumber];
            sw.Stop();
            Console.WriteLine(
                $"{i + 1}. Поиск клиента по его номеру телефона, среди элементов словаря: {sw.ElapsedTicks} тиков");
            sw.Reset();
        }
        Console.WriteLine();

        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getClientsUnderAgeCollection = clientCollection
                .Where(c => c.BirthdayDate > DateTime.Today.AddYears(-30))
                .ToList();
            sw.Stop();
            Console.WriteLine(
                $"{i + 1}. Выборка клиентов, возраст которых ниже определенного значения, среди элементов коллекции: {sw.ElapsedTicks} тиков");
            sw.Reset();
        }
        Console.WriteLine();


        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getClientsUnderAgeDictionary = clientDictionary
                .Where(c => c.Value.BirthdayDate > DateTime.Today.AddYears(-30))
                .ToDictionary(k => k.Key, v => v.Value);
            sw.Stop();
            Console.WriteLine(
                $"{i + 1}. Выборка клиентов, возраст которых ниже определенного значения, среди элементов словаря: {sw.ElapsedTicks} тиков");
            sw.Reset();
        }
        Console.WriteLine();


        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getEmployeeWithMinSalary = employeeCollection
                .Min(e => e.Salary);
            sw.Stop();
            Console.WriteLine(
                $"{i + 1}. Поиск сотрудника с минимальной заработной платой, среди элементов коллекции: {sw.ElapsedTicks} тиков");
            sw.Reset();
        }
        Console.WriteLine();


        for (int i = 0; i < maxItteration; i++)
        {
            sw.Start();
            var getLastClientDictionary1 = clientDictionary.FirstOrDefault(c => c.Key == lastClientPhoneNumber);
            sw.Stop();
            var resFirstMethod = sw.ElapsedTicks;
            sw.Reset();
            
            sw.Start();
            var getLastClientDictionary2 = clientDictionary[lastClientPhoneNumber];
            sw.Stop();
            var resSecondMethod = sw.ElapsedTicks;
            Console.WriteLine($"{i + 1}. Разница между методами FirstOrDefault и поиск по ключу: {resFirstMethod - resSecondMethod} тиков");
            sw.Reset();
        }
    }
}