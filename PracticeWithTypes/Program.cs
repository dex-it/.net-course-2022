using System;
using Models;

namespace PracticeWithTypes;

class Program
{
    static void Main(string[] args)
    {
        Employee e = new Employee();
        IncorrectEmployee(e);
        e.Contract = CorrectEmployee(e.FirstName, e.LastName, e.BirthdayDate, e.PhoneNumber);

        Currency c = new Currency();
        IncorrectCurrency(c);
        c = CorrectCurrency(c);
    }

    static void IncorrectEmployee(Employee e)
    {
        string firstNameText = "Иван";
        string lastNameText = "Иванов";
        DateTime birthdayDateText = DateTime.Parse("23.01.2000");
        int phoneNumberText = 077700077;
        string contractText = $"Работник {firstNameText} {lastNameText} принимается на работу в банк по профессии (должности) \"Банкир\"\n" +
                              $"Дата рождения сотрудника: {birthdayDateText.ToString("dd/MM/yyyy")}\n" +
                              $"Контактный номер: {phoneNumberText}\n";

        e.FirstName = firstNameText;
        e.LastName = lastNameText;
        e.BirthdayDate = birthdayDateText;
        e.PhoneNumber = phoneNumberText;
        e.Contract = contractText;
    }

    static string CorrectEmployee(string firstNameText, string lastNameText, DateTime birthdayDateText, int phoneNumberText)
    {
        string contractText = $"Работник {firstNameText} {lastNameText} принимается на работу в банк по профессии (должности) \"Банкир\"\n" +
                              $"Дата рождения сотрудника: {birthdayDateText.ToString("dd/MM/yyyy")}\n" +
                              $"Контактный номер: {phoneNumberText}\n";
        
        return contractText;
    }
    
    static void IncorrectCurrency(Currency c)
    {
        string codeText = "EUR";
        string nameText = "Евро";
        
        c.Code = codeText;
        c.Name = nameText;
    }
    
    static Currency CorrectCurrency(Currency c)
    {
        string codeText = "EUR";
        string nameText = "Евро";
        
        c.Code = codeText;
        c.Name = nameText;
        
        return c;
    }
}
