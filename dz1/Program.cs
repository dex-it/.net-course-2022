using Models;

namespace PracticeWithTypes
{
    class Programm
    {
        static void Main()
        {
            Employee employee = new Employee("Виталий",19);
            ChangeCurrency(employee);
            ChangeContract(employee);
            employee.ShowEmployee();
        }
        public static void ChangeContract(Employee employee)
        {
            employee.ChangeContracts();
        }
        public static void ChangeCurrency(Employee employee)
        {
            Currency cur = new Currency(EnumCur.EUR, 400);
            employee.ChangeCurrency(cur);
        }
    }
}

