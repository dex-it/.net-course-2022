using Models;

namespace Services;

public class ClientStorage
{
    public readonly Dictionary<Client, List<Account>> ClientsDictionary = new Dictionary<Client, List<Account>>();

    public void AddClient(Client client)
    {
        var usdCurrency = new Currency
        {
            Code = 840,
            Name = "USD"
        };
        var eurCurrency = new Currency
        {
            Code = 978,
            Name = "EUR"
        };
        var accounts = new List<Account>
        {
            new Account
            {
                Amount = 1000F,
                Currency = usdCurrency
            },
            new Account
            {
                Amount = 200F,
                Currency = eurCurrency
            }
        };
        ClientsDictionary.Add(client, accounts);
    }
    
    public void AddClient(Client client, List<Account> accounts)
    {
        ClientsDictionary.Add(client, accounts);
    }
}