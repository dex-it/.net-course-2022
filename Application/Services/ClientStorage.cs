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
        var account = new List<Account>
        {
            new Account
            {
                Amount = 1000F,
                Currency = usdCurrency
            }
        };
        
        ClientsDictionary.Add(client, account);
    }
    
    public void AddAccount(Client client, Account account)
    {
        ClientsDictionary[client].Add(account);
    }
}