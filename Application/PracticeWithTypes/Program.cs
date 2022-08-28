using System;
using Models;

namespace PracticeWithTypes;

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee{
            FirstName = "Иван",
            LastName = "Иванов",
            BirthdayDate = DateTime.Parse("23.01.2000"),
            PhoneNumber = 077700077,
            
        };
        UpdateContractEmployeeIncorrect(employee);
        employee.Contract = UpdateContractEmployeeCorrect(employee.FirstName, employee.LastName, employee.BirthdayDate, employee.PhoneNumber);

        Currency currency = new Currency
        {
            Code = 978,
            Name = "euro"
        };
        int newCurrencyCode = 840;
        string newCurrencyName = "dollar";
        UpdateCurrencyIncorrect(currency, newCurrencyCode, newCurrencyName);
        currency = UpdateCurrencyCorrect(currency, newCurrencyCode, newCurrencyName);
    }
    static void UpdateContractEmployeeIncorrect(Employee employee)
    {
       employee.Contract = $"Работник {employee.FirstName} {employee.LastName} принимается на работу в банк по профессии (должности) \"Банкир\"\n" +
                           $"Дата рождения сотрудника: {employee.BirthdayDate.ToString("dd/MM/yyyy")}\n" +
                           $"Контактный номер: {employee.PhoneNumber}\n";
    }

    static string UpdateContractEmployeeCorrect(string firstNameText, string lastNameText, DateTime birthdayDateText, int phoneNumberText)
    {
        return $"Работник {firstNameText} {lastNameText} принимается на работу в банк по профессии (должности) \"Банкир\"\n" + 
               $"Дата рождения сотрудника: {birthdayDateText.ToString("dd/MM/yyyy")}\n" + 
               $"Контактный номер: {phoneNumberText}\n";
    }
    
    static void UpdateCurrencyIncorrect(Currency currency, int code, string name)
    {
        currency.Code = code;
        currency.Name = name;
    }
    
    static Currency UpdateCurrencyCorrect(Currency currency, int code, string name)
    {
        currency.Code = code;
        currency.Name = name;
        
        return currency;
    }
}
