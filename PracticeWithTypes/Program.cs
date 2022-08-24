using Models;
using System;

public class PracticeWithTypes
{
    static void Main()
    {
        Person tom = new Person("Tom", 25);
        tom.Print();

        Employee emp = new Employee("Bob", 32);
        ChangeContract(emp);

        Currency curs = new Currency();
        curs.currency = "Rub";
        curs.price = 0.22;
        Console.WriteLine($"Валюта {curs.currency} курс {curs.price}");
        ChangeCur(curs);
    }

    /* а) метод, обновляющий контракт сотрудника. Принимает на вход сотрудника и создает контракт (свойство класса “Employee”, строка) наоснове его данных. 
  Результат присваивается обратно в тело сотрудника, свойству “Contract”; 
    ? */
    static void ChangeContract(Employee emp)
    {
        emp.contract = "Контракт";
        Console.WriteLine($"Имя {emp.name} возраст {emp.age} контракт {emp.contract}");
    }

    /* б) метод обновляющий валюты. (Метод принимает на вход экземпляр структуры “Currency”, меняет значение ее свойств);
    Сравнить результат работы методов и объяснить его.  */
    static void ChangeCur(Currency curs_p)
    {
        curs_p.currency = "USD";
        curs_p.price = 16.3;
        Console.WriteLine($"Валюта {curs_p.currency} курс {curs_p.price}");
    }
}