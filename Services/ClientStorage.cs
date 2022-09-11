using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientStorage
    {
        public readonly Dictionary<Client, List<Account>> dictionaryClient = new Dictionary<Client, List<Account>>();

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
            if (dictionaryClient.ContainsKey(client))
            {
                throw new ExistsException("Такой клиент уже существует");
            }
            dictionaryClient.Add(
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
