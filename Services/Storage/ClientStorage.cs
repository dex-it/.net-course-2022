using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Exceptions;

namespace Services.Storage
{
    public class ClientStorage : IClientStorage
    {
        public Dictionary<Client, Account> Data
        { get => throw new NotImplementedException(); }


        public void Add(Client client)
        {
            var Data = new Dictionary<Client, List<Account>>();
            Data.Add(
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

        public void AddAccount(Client client, Account account)
        {
            var Data = new Dictionary<Client, List<Account>>();
            Account newAccount = new Account
            {
                Currency = new Currency
                {
                    Code = 4,
                    Name = "RUB",
                },
                Amount = 0
            };
            Data[client].Add(newAccount);
        }

        public void Remove(Client item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(Client client, Account account)
        {
            throw new NotImplementedException();
        }

        public void Update(Client item)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(Client client, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
