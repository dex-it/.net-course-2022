using Models;

namespace PracticeWithTypes
{
    class Programm
    {
        static void Main()
        {
            Employee employee = new Employee();
            employee.Name = "Виталий";
            employee.Age = 19;

            var cur = new Currency
            {
                Cur = EnumCur.EUR,
                Salary = 1000
            };
            employee.Curr = cur; 

            employee.Contract = ChangeContracts(employee);

            employee.ShowEmployee();
        }
        private static string ChangeContracts(Employee employee)
        {
            if (employee.Name.Length == 0 || employee.Name == null)
            {
                Console.WriteLine("Имя слишком короткое");
                return "Нет контракта";
            }
            if (employee.Age < 14)
            {
                Console.WriteLine("По ТК ПМР нельзя работать людям младше 14 лет");
                return "Нет контракта";

            }
            return $"Contract: {employee.Name} - {employee.Age} - {employee.Curr.Cur} - { (employee.Curr.Salary == 0 ? "волонтёр" : employee.Curr.Salary) }";
        }
    }
}

