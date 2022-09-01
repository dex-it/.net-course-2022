using Services;
using Models;
using System.Diagnostics;

public class Program
{
    static void Main()
    {
        var testDataGenerator = new TestDataGenerator();
        var sw = new Stopwatch();
        var clientList = testDataGenerator.GetClientsList();
        var clientDictionary = testDataGenerator.GetClientsDictionary();
        var employeesList = testDataGenerator.GetEmployeesList();
        for (int i = 0; i < 4; i++)
        {
            sw.Start();
            clientList.Find(p => p.Phone == i);
            sw.Stop();
            Console.WriteLine($"{i}Поиск клиента по его номеру телефона в list занял: {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }

        clientList.Add(new Client
        {
            Name = "Ivan",
            birtDate = new DateTime(1990, 01, 01),
            PasportNum = 324786,
            Phone = 77520034
        });
        sw.Start();
        clientList.Find(p => p.Phone == 77520034);
        sw.Stop();
        Console.WriteLine($"Поиск клиента Ivan по его номеру телефона в list занял: {sw.Elapsed.Milliseconds}");
        sw.Restart();

        for (int i = 0; i < 4; i++)
        {
            sw.Start();
            clientDictionary.ContainsKey(i);
            sw.Stop();
            Console.WriteLine($"\n{i}Поиск клиента по его номеру телефона в Dictionary занял: {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }

        var clientsUnder18 = clientList.Where(y => DateTime.Now.Year - y.birtDate.Year < 18).ToList();
        foreach (Client client in clientsUnder18)
        {
            Console.WriteLine("\nКлиенты младше 18:" +
                              $"\nИмя : {client.Name}" +
                              $" \nНомер паспорта : {client.PasportNum}" +
                              $" \nДата рождения : {client.birtDate}");
        }
        var employeeMinSalary = employeesList.FirstOrDefault(s => s.Salary == employeesList.Min(s => s.Salary));
        Console.WriteLine($"\nСотрудник с минимально заработной платой:" +
                          $"\nИмя : {employeeMinSalary.Name}" +
                          $"\nНомер паспорта : {employeeMinSalary.PasportNum}" +
                          $"\nЗарплата : {employeeMinSalary.Salary}");
        for (int i = 0; i < 4; i++)
        {
            sw.Start();
            var lastСlientByFirstOrDefault = clientDictionary.FirstOrDefault(p => p.Key == clientDictionary.Keys.Last());
            sw.Stop();
            Console.Write($"\n{i} Поиск последнего клиента списка по ключу занял(способ FirstOrDefault): {sw.Elapsed.Milliseconds}");
            sw.Restart();

            sw.Start();
            var lastСlientByKey = clientDictionary[clientDictionary.Keys.Last()];
            sw.Stop();
            Console.Write($"\n{i} Поиск последнего клиента списка по ключу занял(способ с ключом): {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }
    }
}
