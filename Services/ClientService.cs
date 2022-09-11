using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Exceptions;



namespace Services
{
    public class ClientService
    {

        private Dictionary<Client, List<Account>> dictionaryClient = new Dictionary<Client, List<Account>>();

        public void AddClient(Client client)
        {
            if (client.PasportNum == 0)
            {
                throw new NoPasportData("У клиента нет паспортных данных");
            }

            if (DateTime.Now.Year - client.BirtDate.Year < 18)
            {
                throw new Under18Exception("Клиент меньше 18 лет");
            }
            if (dictionaryClient.ContainsKey(client))
            {
                throw new ExistsException("Такой клиент уже существует");
            }
            dictionaryClient.Add(
                client,
                new List<Account>
                {
                    new Account
                    {
                        Currency = new Currency
                        {
                            Code = 1,
                            Name = "Euro",
                        },
                        Amount = 0
                    }
                });
        }


        public void AddAccount(Client client)
        {
            if (!dictionaryClient.ContainsKey(client))
            {
                throw new ExistsException("Такого клиента нет");
            }
            Account newAccount = new Account
            {
                Currency = new Currency
                {
                    Code = 4,
                    Name = "RUB",
                },
                Amount = 0
            };
            if (dictionaryClient[client].FirstOrDefault(p => p.Currency.Name == newAccount.Currency.Name) != null)
            {
                throw new ExistsException("У клиента уже есть такой счет");
            }
            dictionaryClient[client].Add(newAccount);
        }
    }
}
