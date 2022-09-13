using Models;
using Services.Exceptions;
using System.Collections.Generic;

namespace Services.Storage
{
    public class ClientStorage : IClientStorage
    {
        public Dictionary<Client, Account> Data 
        { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
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
            throw new NotImplementedException();
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
