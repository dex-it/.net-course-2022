using Services.Exceptions;
using Models;
using Services.Storages;

namespace Services;

public class ClientService
{
    private IClientStorage _clientStorage;

    public ClientService(IClientStorage clientStorage)
    {
        _clientStorage = clientStorage;
    }

    public void AddClient(Client client)
    {
        if (client.BirthdayDate > DateTime.Now.AddYears(-18))
        {
            throw new AgeLimitException("Клиент моложе 18 лет");
        }
        
        if (client.Passport == 0)
        {
            throw new PassportDataEmptyException("У клиента нет паспортных данных");
        }

        _clientStorage.Add(client);
    }
    
    public void AddAccount(Client client, Account account)
    {
        if (_clientStorage.Data.ContainsKey(client))
        {
            throw new ClientNotExistException("Клиент не существует");
        }

        _clientStorage.AddAccount(client, account);
    }
    
    public Dictionary<Client, List<Account>> GetClients(ClientFilter clientFilter)
    {
        if (clientFilter.DateEnd == DateTime.MinValue)
        {
            clientFilter.DateEnd = DateTime.Today;
        }
        
        var selection = _clientStorage.Data.
            Where(c => c.Key.BirthdayDate >= clientFilter.DateStart).
            Where(c => c.Key.BirthdayDate <= clientFilter.DateEnd);

        if (!string.IsNullOrEmpty(clientFilter.FirstName))
            selection = selection.Where(c => c.Key.FirstName == clientFilter.FirstName);
        
        if (!string.IsNullOrEmpty(clientFilter.LastName))
            selection = selection.Where(c => c.Key.LastName == clientFilter.LastName);

        if (clientFilter.Passport != 0)
            selection = selection.Where(c => c.Key.Passport == clientFilter.Passport);
        
        if (clientFilter.PhoneNumber != 0)
            selection = selection.Where(c => c.Key.PhoneNumber == clientFilter.PhoneNumber);
        
        return selection.ToDictionary(c => c.Key, a => a.Value );
    }
}