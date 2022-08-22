using Models;

class Example
{
    static void Main()
    {
        DateTime birthday = new DateTime(1986, 2, 9);
        Employee human = new Employee("Алексей",14714,"077881886",birthday);

        UpdateContractEmployee(human); // меняет контракт, используя неправильный подход
        Console.WriteLine(human.Contract);
        
        human.Contract = UpdateContractEmployeeCorrect(human); // меняет контракт, используя правильный подход
        Console.WriteLine(human.Contract);

        Currency currency = new Currency();
        currency.Code = 978;
        currency.Value = "EUR";
        
        UpdateCurrency(currency); // не меняет свойства валюты
        Console.WriteLine("Изначально используется валюта EUR, пробуем поменять. Результат " + currency.Value);
        
        currency = UpdateCurrencyCorrect(currency); // меняет свойства валюты
        Console.WriteLine("Изначально используется валюта EUR, пробуем поменять. Результат " + currency.Value);
        
        // неправильный подход 
        void UpdateContractEmployee(Employee employee)
        {
            employee.Contract = "Здравствуйте, дорогой " + employee.Name + ", " + employee.Birthday.Year + 
                                " года рождения. С Вами заключен новый контракт, в котором указаны " + 
                                "номер паспорта " + employee.Passport + " и номер телефона " +
                                employee.Phone + ". Проверьте пожалуйста правильность данных.";
        }

        // правильный подход
        string UpdateContractEmployeeCorrect(Employee employee)
        {
            return "Здравствуйте, дорогой " + employee.Name + ", " + employee.Birthday.Year + 
                   " года рождения. С Вами заключен новый контракт, в котором указаны " + 
                   "номер паспорта " + employee.Passport + " и номер телефона " +
                   employee.Phone + ". Проверьте пожалуйста правильность данных.";
        }

        // не меняет свойства валюты
        void UpdateCurrency(Currency currency)
        {
            currency.Code = 840;
            currency.Value = "USD";
        }
        
        // меняет свойства валюты
        Currency UpdateCurrencyCorrect(Currency currency)
        {
            currency.Code = 840;
            currency.Value = "USD";
            return currency;
        }
    }
}
