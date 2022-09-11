namespace Services.Exceptions;

public class PassportDataEmptyException : Exception
{
    public PassportDataEmptyException(string message) : base(message)
    {
    }
}