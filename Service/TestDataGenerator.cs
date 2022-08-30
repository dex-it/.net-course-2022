using System;
using System.Collections.Generic;
using System.Linq;
using Models;


namespace Services
{
    class TestDataGenerator
    {
        static void Main(string[] args)
        {
            var ClientsList = GetClientsList();
        }

        public static List<Client> GetClientsList()
        { 
            Random Rand = new Random(); 
            var clients = new List<Client>();

            for (int i = 0; i < 1000; i++)
            {
                clients.Add(new Client
                {
                    Name = "Name_" + i,
                    Data = new DateTime(1999, 01, 01),
                    PasportNum = Rand.Next(100000, 999999),
                    Phone = 77500000 + i
                }) ;
            }
                return clients;
        }
        public static Dictionary<int, Client> GetClientsDyctionar()
        {
            Random Rand = new Random();
            var clients = new Dictionary<int, Client>();


            for (int i = 0; i < 1000; i++)
            {
                Client client = new Client();
                clients.Add(
                client.Phone,
                new Client
                {
                    Name = "Name_" + i,
                    Data = new DateTime(1999, 01, 01),
                    PasportNum = Rand.Next(100000, 999999),
                    Phone = 77500000 + i
                });
            }

            return clients;
        }
        public static List<Employee> GetEmployeesList()
        {
            Random rand = new Random();
            var employees = new List<Employee>();

            for (int i = 0; i < 1000; i++)
            {
                employees.Add(new Employee
                {
                    Name = "Name_" + i,
                    Data = new DateTime(1999, 01, 01),
                    PasportNum = rand.Next(100000, 999999)
                });
            }
            return employees;
        }

    }
}
