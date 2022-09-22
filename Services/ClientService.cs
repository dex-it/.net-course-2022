using Models;
using Services.Exceptions;
using Services.Filters;
using Services.Storage;

namespace Services
{
    public class ClientService
    {

        private IClientStorage _iClientStorage { get; set; }

        public ClientService(IClientStorage iClientStorage)
        {
            _iClientStorage = iClientStorage;
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
            _iClientStorage.Add(client);
        }

        public Dictionary<Client, List<Account>> GetClients(ClientFilter clientFilter)
        {
            var selection = _iClientStorage.Data.Select(p => p);

            if (clientFilter.Name != null)
                selection = selection.
                    Where(p => p.Key.Name == clientFilter.Name);

            if (clientFilter.PasportNum != 0)
                selection = selection.
                    Where(p => p.Key.PasportNum == clientFilter.PasportNum);

            if (clientFilter.StartDate != new DateTime())
                selection = selection.
                    Where(p => p.Key.BirtDate == clientFilter.StartDate);

            if (clientFilter.EndDate != new DateTime())
                selection = selection.
                    Where(p => p.Key.BirtDate == clientFilter.EndDate);

            return selection.ToDictionary(k => k.Key, k => k.Value);
        }

        public void AddAccount(Client client, Account account)
        {
            if (!_iClientStorage.Data.ContainsKey(client))
            {
                throw new ExistsException("Такого клиента нет");
            }
            if (_iClientStorage.Data[client].FirstOrDefault(p => p.Currency.Name == account.Currency.Name) != null)
            {
                throw new ExistsException("У клиента уже есть такой счет");
            }
            _iClientStorage.AddAccount(client,account);
        }
        public void UpdateClient(Client client)
        {
            if (!_iClientStorage.Data.ContainsKey(client))
            {
                throw new ExistsException("Такого клиента нет");
            }

            _iClientStorage.Update(client);

        }
        public void UpdateAccount(Client client, Account account)
        {
            if (!_iClientStorage.Data.ContainsKey(client))
            {
                throw new ExistsException("Такого клиента нет");
            }

            if (_iClientStorage.Data[client].FirstOrDefault(p => p.Currency.Name == account.Currency.Name) == null)
            {
                throw new ExistsException("У клиента нет такого счета");
            }

            _iClientStorage.UpdateAccount(client, account);

        }
    }
}