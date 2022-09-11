using Models;

namespace Services;

public class ClientStorage
{
    public readonly List<Client> Clients = new List<Client>();

    public void AddClient(Client client)
    {
        Clients.Add(client);
    }
}