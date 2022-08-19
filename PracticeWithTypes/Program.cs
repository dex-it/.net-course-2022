using Models;
using System;

namespace PracticeWithTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void UpdateContact(Employee employee)
        {
            employee.Contract = $"{employee.FirstName} {employee.LastName} {employee.Patronymic}," +
                $" родившийся {employee.BirthDate.ToString()}, с пасспартом {employee.Passport} принят на работу в Dex!";
        }
        public static void UpdateCurrency(Currency currency, string name, decimal cost, int code)
        {
            currency.Code = code;
            currency.Cost = cost;
            currency.Name = name;
        }
    }
}
