namespace Models;

public class Employee : Person
{
    public int Salary { get; set; }
    public string Contract { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;
        if (!(obj is Employee))
            return false;
        var employee = (Employee)obj;
        return employee.Salary == Salary &&
               employee.Contract == Contract &&
               employee.Contract == Contract &&
               employee.FirstName == FirstName &&
               employee.LastName == LastName &&
               employee.BirthdayDate == BirthdayDate &&
               employee.PhoneNumber == PhoneNumber;
    }

    public override int GetHashCode()
    {
        return Salary.GetHashCode() *
               Contract.GetHashCode() *
               FirstName.GetHashCode() *
               LastName.GetHashCode() *
               BirthdayDate.GetHashCode() *
               PhoneNumber.GetHashCode();
    }
}