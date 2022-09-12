using Services.Exceptions;
using Models;

namespace Services;

public class ClientService
{
    private readonly List<Client> _clients;

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

        _clients.Add(client);
    }
}