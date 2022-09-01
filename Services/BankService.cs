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
    }
}