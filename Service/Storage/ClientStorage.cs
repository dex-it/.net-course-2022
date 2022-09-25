using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ModelsDb;
using Services.Exceptions;

namespace Services.Storage
{
    public class ClientStorage : IClientStorage
    {
        private DbBank data = new DbBank();

        public DbBank Data => data;


        public void Add(ClientDb client)
        {

            Data.clients.Add(client);
            Data.accounts.Add(
              new AccountDb
              {
                  Currency = new CurrencyDb { Name = "Euro",Code = 1},
                  Amount = 0,
                  Client = client
              });
            Data.SaveChanges();
        }

        public void Remove(ClientDb client)
        {
            Data.clients.Remove(client);
            Data.SaveChanges();
        }

        public void Update(ClientDb client)
        {
            Data.clients.Update(client);
            Data.SaveChanges();
        }

        public void AddAccount(AccountDb account)
        {
            Data.accounts.Add(account);
            Data.SaveChanges();
        }

        public void RemoveAccount(AccountDb account)
        {
            Data.accounts.Remove(account);
            Data.SaveChanges();
        }

        public void UpdateAccount(AccountDb account)
        {
            Data.accounts.Update(account);
            Data.SaveChanges();
        }
    }
}
