namespace Services.Exceptions;

public class ClientNotExistException : Exception
{
    public ClientNotExistException(string message) : base(message)
    {
    }
}