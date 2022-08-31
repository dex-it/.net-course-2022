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
        for (int i = 0; i < 10; i++)
        {
            sw.Start();
            clientList.Find(p => p.Phone == 77500004);
            sw.Stop();
            Console.WriteLine($"Поиск клиента по его номеру телефона в list занял: {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }
        for (int i = 0; i < 10; i++)
        {
            sw.Start();
            clientDictionary.ContainsKey(77500004);
            sw.Stop();
            Console.WriteLine($"\nПоиск клиента по его номеру телефона в Dictionary занял: {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }

        var clientsUnder18 = clientList.Where(y => DateTime.Now.Year - y.DOB.Year < 18).ToList();
        foreach (Client client in clientsUnder18)
        {
            Console.WriteLine("\nКлиенты младше 18:" +
                              $"\nИмя : {client.Name}" +
                              $" \nНомер паспорта : {client.PasportNum}" +
                              $" \nДата рождения : {client.DOB}");
        }
        var employeeMinSalary = employeesList.FirstOrDefault(s => s.Salary == employeesList.Min(s => s.Salary));
        Console.WriteLine($"\nСотрудник с минимально заработной платой:" +
                          $"\nПолное имя : {employeeMinSalary.Name}" +
                          $"\nНомер паспорта : {employeeMinSalary.PasportNum}" +
                          $"\nЗарплата : {employeeMinSalary.Salary}");
        for (int i = 0; i < 10; i++)
        {
            sw.Start();
            var lastСlientByFirstOrDefault = clientDictionary.FirstOrDefault(p => p.Key == clientDictionary.Keys.Last());
            sw.Stop();
            Console.Write($"\nПоиск последнего клиента списка по ключу занял(способ FirstOrDefault): {sw.Elapsed.Milliseconds}");
            sw.Restart();

            sw.Start();
            var lastСlientByKey = clientDictionary[clientDictionary.Keys.Last()];
            sw.Stop();
            Console.Write($"\nПоиск последнего клиента списка по ключу занял(способ с ключом): {sw.Elapsed.Milliseconds}");
            sw.Restart();
        }
    }
}
