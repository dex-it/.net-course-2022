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
            if (client.PasportNum ==0)
            { 
                throw new NoPasportData("У клиента нет паспортных данных"); 
            }    
                
            if (DateTime.Now.Year - client.BirtDate.Year < 18)
            {
                throw new Under18Exception("Клиент меньше 18 лет");
            }
        }
        public void AddAccount(Client client, Account account)
        {
            if (dictionaryClient.ContainsKey(client))
            {
                throw new AccountExistsException("Такой клиент уже существует");
            }
        }
    }
}
