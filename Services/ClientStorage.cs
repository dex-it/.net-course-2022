using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientStorage
    {
        public readonly Dictionary<Client, List<Account>> _dictionaryClient = new Dictionary<Client, List<Account>>();

        public void AddClient(Client client)
        {
            _dictionaryClient.Add(
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
    }
}
