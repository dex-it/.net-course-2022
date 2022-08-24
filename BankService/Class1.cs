using Models;

namespace BankService
{
    public class Class1
    {
        public static int CalculateOwnerSalary(int ownerCount, float bankProfit, float bankExpenses)
        {
            return Convert.ToInt32((bankProfit - bankExpenses)/ownerCount);
        }

        public static Employee ClientToEmployee(Client client)
        {
            Employee employee = client;
            return employee;          
        }
    }
}