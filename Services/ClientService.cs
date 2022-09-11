﻿using Services.Filters;
using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientService
    {

        private ClientStorage _clientStorage { get; set; }

        public ClientService(ClientStorage clientStorage)
        {
            _clientStorage = clientStorage;
        }

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
            _clientStorage.AddClient(client);
        }

        public Dictionary<Client, List<Account>> GetClients(ClientFilter clientFilter)
        {
            var selection = _clientStorage._dictionaryClient.Select(p => p);

            if (clientFilter.Name != null)
                selection = _clientStorage._dictionaryClient.
                    Where(p => p.Key.Name == clientFilter.Name);

            if (clientFilter.PasportNum != 0)
                selection = _clientStorage._dictionaryClient.
                    Where(p => p.Key.PasportNum == clientFilter.PasportNum);

            if (clientFilter.StartDate != new DateTime())
                selection = _clientStorage._dictionaryClient.
                    Where(p => p.Key.BirtDate == clientFilter.StartDate);

            if (clientFilter.EndDate != new DateTime())
                selection = _clientStorage._dictionaryClient.
                    Where(p => p.Key.BirtDate == clientFilter.EndDate);

            return selection.ToDictionary(k => k.Key, k => k.Value);
        }


        //public void AddAccount(Client client)
        //{
        //    if (!dictionaryClient.ContainsKey(client))
        //    {
        //        throw new ExistsException("Такого клиента нет");
        //    }
        //    Account newAccount = new Account
        //    {
        //        Currency = new Currency
        //        {
        //            Code = 4,
        //            Name = "RUB",
        //        },
        //        Amount = 0
        //    };
        //    if (dictionaryClient[client].FirstOrDefault(p => p.Currency.Name == newAccount.Currency.Name) != null)
        //    {
        //        throw new ExistsException("У клиента уже есть такой счет");
        //    }
        //    dictionaryClient[client].Add(newAccount);
        //}
    }
}
