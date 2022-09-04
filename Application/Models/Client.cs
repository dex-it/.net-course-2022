namespace Models;

public class Client : Person
{
    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (!(obj is Client))
            return false;
        var client = (Client) obj;
        return client.FirstName == FirstName &&
               client.LastName == LastName &&
               client.BirthdayDate == BirthdayDate &&
               client.PhoneNumber == PhoneNumber;
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode() *
               LastName.GetHashCode() *
               BirthdayDate.GetHashCode() *
               PhoneNumber.GetHashCode();
    }
}