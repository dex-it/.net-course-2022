using Models;
using System;


namespace BankService
{
    public class BankService
    {
//        а) метод расчета зарплаты владельцев банка = прибыль банка -
//расходы / количество владельцев(при условии что владелец тоже
//сущность Employee и ЗП это int)
//б) метод преобразования клиента банка в сотрудника, метод
//принимает на вход сущность “Client” приводит его к типу “Employee” и
//возвращает его в качестве результата для дальнейшей работы.

        public static decimal Payroll(decimal bankProfit, decimal expenses, params Employee[] employees)
        {
            var result = bankProfit - expenses / employees.Length;
            return result;
        }

        public static void 

    }
}
