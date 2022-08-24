using Models;

namespace PracticeWithTypes
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Employee employee = new Employee { name = "Иван", surname = "Иванов", passport_id = 545555, company = "Рога и копыта", position = "охранника", salary = 100 };

            // incorrect way
            updateContractIncorrect(employee);
            Console.WriteLine(employee.contract);

            // correct way
            employee.contract = updateContractCorrect(employee);
            Console.WriteLine(employee.contract);


            Currency currency = new Currency { value = "EUR", code = 978 };

            // incorrect way
            changeCurrencyIncorrect(currency);
            Console.WriteLine($"Новая валюта {currency.value}, c общепринятым кодом {currency.code}");

            // correct way
            currency = changeCurrencyCorrect(currency);
            Console.WriteLine($"Новая валюта {currency.value}, c общепринятым кодом {currency.code}");

        }

        public static void updateContractIncorrect(Employee employee)
        {
            employee.contract = "$Договор: сотрудник {employee.surname} {employee.name},  паспорт номер {employee.passport_id}, принят на работу в компанию '{employee.company}' на должность {employee.position} с зарплатой {employee.salary} рублей.";
        }

        public static string updateContractCorrect(Employee employee)
        {
            return $"Договор: сотрудник {employee.surname} {employee.name},  паспорт номер {employee.passport_id}, принят на работу в компанию '{employee.company}' на должность {employee.position} с зарплатой {employee.salary} рублей.";
        }

        public static void changeCurrencyIncorrect(Currency currency)
        {
            currency.value = "USD";
            currency.code = 840;

        }
        public static Currency changeCurrencyCorrect(Currency currency)
        {
            currency.value = "USD";
            currency.code = 840;

            return currency;
        }
    }


}