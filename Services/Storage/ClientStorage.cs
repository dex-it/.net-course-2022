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
        public Dictionary<Client, List<Account>> Data = new Dictionary<Client, List<Account>>();

        Dictionary<Client, List<Account>> IClientStorage.Data => throw new NotImplementedException();

        public void Add(Client client)
        {
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
            var oldClient = Data.Keys.First(p => p.PasportNum == item.PasportNum);

            item = new Client
            {
                Name = oldClient.Name,
                PasportNum = oldClient.PasportNum,
                BirtDate = oldClient.BirtDate
            };

            Remove(oldClient);
            Add(item);
        }

        public void UpdateAccount(Client client, Account account)
        {
            int accountUpdate = Data[client].IndexOf(Data[client].First((p => p.Currency.Name == account.Currency.Name)));

            Data[client][accountUpdate] = new Account
            {
                Currency = new Currency
                {
                    Code = account.Currency.Code,
                    Name = account.Currency.Name,
                },
                Amount = account.Amount
            };
        }
    }
}
