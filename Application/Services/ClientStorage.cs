using Models;

namespace Services;

public class ClientStorage
{
    public readonly Dictionary<Client, Account> ClientsDictionary = new Dictionary<Client, Account>();

    public void AddClient(Client client)
    {
        var usdCurrency = new Currency
        {
            Code = 840,
            Name = "USD"
        };
        var accounts = new Account
        {
            Amount = 1000F,
            Currency = usdCurrency
        };
        ClientsDictionary.Add(client, accounts);
    }
    
    public void AddAccount(Client client, Account account)
    {
        if (!ClientsDictionary.TryAdd(client, account))
        {
            ClientsDictionary[client] = account;
        }
    }
}