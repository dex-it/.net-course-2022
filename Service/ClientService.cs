using Models;
using ModelsDb;
using Services.Exceptions;
using Services.Filters;
using Services.Storage;

namespace Services
{
    public class ClientService
    {

        DbBank _dbContext;

        public ClientService()
        {
            _dbContext = new DbBank();
        }
        public ClientDb GetClient(Guid clientId)
        {
            var client = _dbContext.clients.FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                throw new ExistsException("Этого клиента не сущетсвует");
            }

            return _dbContext.clients.FirstOrDefault(c => c.Id == clientId);
        }

        public void AddClient(ClientDb client)
        {
            if (client.PasportNum == 0)
            {
                throw new NoPasportData("У клиента нет паспортных данных");
            }

            if (DateTime.Now.Year - client.BirtDate.Year < 18)
            {
                throw new Under18Exception("Клиент меньше 18 лет");
            }
            var account = new AccountDb
            {
                Id = Guid.NewGuid(),
                ClientId = client.Id
            };
            var currency = new CurrencyDb()
            {
                Id = Guid.NewGuid(),
                Name = "RUB",
                Code = 2,
                AccountId = account.Id
            };
            _dbContext.clients.Add(client);
            _dbContext.accounts.Add(account);
            _dbContext.currencies.Add(currency);
        }

        public List<ClientDb> GetClients(ClientFilter clientFilter)
        {
            var selection = _dbContext.clients.Select(p => p);

            if (clientFilter.Name != null)
                selection = selection.
                    Where(p => p.Name == clientFilter.Name);

            if (clientFilter.PasportNum != 0)
                selection = selection.
                    Where(p => p.PasportNum == clientFilter.PasportNum);

            if (clientFilter.StartDate != new DateTime())
                selection = selection.
                    Where(p => p.BirtDate == clientFilter.StartDate);

            if (clientFilter.EndDate != new DateTime())
                selection = selection.
                    Where(p => p.BirtDate == clientFilter.EndDate);

            return selection.ToList();
        }

        public void AddAccount(AccountDb account)
        {
            if (account.ClientId == null)
                throw new ExistsException("Этот аккаунт не привязан ни к одному клиенту");

            _dbContext.accounts.Add(account);
        }

        public void UpdateClient(ClientDb client)
        {
            var oldClient = _dbContext.clients.FirstOrDefault(c => c.Id == client.Id);

            if (!_dbContext.clients.Contains(oldClient))
            {
                throw new ExistsException("Этого клиента не существует");
            }

            oldClient.Id = client.Id;
            oldClient.Name = client.Name;
            oldClient.PasportNum = client.PasportNum;
            oldClient.BirtDate = client.BirtDate;
            oldClient.Accounts = client.Accounts;

        }

        public void UpdateAccount(AccountDb account)
        {
            var oldAccount = _dbContext.accounts.FirstOrDefault(c => c.Id == account.Id);
            var accountClient = _dbContext.clients.FirstOrDefault(c => c.Id == oldAccount.Id);

            if (!accountClient.Accounts.Select(x => x.Id).Contains(oldAccount.Id))
            {
                throw new ExistsException("Данного аккаунта не существует");
            }

            oldAccount.Id = account.Id;  
            oldAccount.Currency = account.Currency;
            oldAccount.Amount = account.Amount;

        }
        public void DeleteClient(Guid clientId)
        {
            var client = _dbContext.clients.FirstOrDefault(c => c.Id == clientId);

            if (client == null)
                throw new ExistsException("Этого клиента не сущетсвует");
            else
                _dbContext.clients.Remove(client);

        }
        public void DeleteAccount(Guid accountId)
        {
            var account = _dbContext.accounts.FirstOrDefault(c => c.Id == accountId);

            _dbContext.accounts.Remove(account);
        }
    }
}