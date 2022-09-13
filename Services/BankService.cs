using Models;

namespace Services
{
    public class BankService
    {
        public int SalaryOwnerOfBank(int bankProfit, int expenses, int owners)
        {
            return (int)((bankProfit - expenses) / owners);
        }
        public Employee ClientInEmployee(Client client)
        {
            return new Employee()
            {
                Name = client.Name,
                BirtDate = client.BirtDate,
                PasportNum = client.PasportNum,
                Salary = 0
            };
        }

        public List<Person> BlackList = new List<Person>();
        public void AddBonus<T>(T person) where T : Person
        {
            person.Bonus+=50;
        }
        public void AddToBlackList<T>(T person) where T : Person
        {
            if (!BlackList.Contains(person))
                BlackList.Add(person);
        }
        public bool PersonInBlackList<T>(T person) where T : Person
        {
            return BlackList.Contains(person);
        }
    }
}