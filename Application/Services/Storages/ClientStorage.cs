using Models;

namespace Services.Storages;

public class ClientStorage : IClientStorage
{
    public Dictionary<Client, List<Account>> Data { get; }

    public ClientStorage()
    {
        Data = new Dictionary<Client, List<Account>>();
    }
    
    public void Add(Client client)
    {
        var usdCurrency = new Currency
        {
            Code = 840,
            Name = "USD"
        };
        var account = new List<Account>
        {
            new Account
            {
                Amount = 1000F,
                Currency = usdCurrency
            }
        };
        
        Data.Add(client, account);
    }

    public void Update(Client client)
    {
    }

    public void Delete(Client client)
    {
        Data.Remove(client);
    }
    
    public void AddAccount(Client client, Account account)
    {
        Data[client].Add(account);
    }
    
    public void UpdateAccount(Client client, Account account)
    {
    }
    
    public void DeleteAccount(Client client, Account account)
    {
        Data[client].RemoveAll(acc => acc.Equals(account));
    }
}