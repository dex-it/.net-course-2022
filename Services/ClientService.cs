using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Filters;
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
            Dictionary<Client, List<Account>> filteredDictionary = new Dictionary<Client, List<Account>>();

            if (clientFilter.Name != null)
                filteredDictionary = _clientStorage._dictionaryClient.Where(p => p.Key.Name == clientFilter.Name).ToDictionary(k => k.Key, k => k.Value);

            if (clientFilter.PasportNum != 0)
                filteredDictionary = _clientStorage._dictionaryClient.Where(p => p.Key.PasportNum == clientFilter.PasportNum).ToDictionary(k => k.Key, k => k.Value);

            if (clientFilter.BirtDate != new DateTime())
                filteredDictionary = _clientStorage._dictionaryClient.Where(p => p.Key.BirtDate.Date == clientFilter.BirtDate.Date).ToDictionary(k => k.Key, k => k.Value);

            return filteredDictionary;
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
