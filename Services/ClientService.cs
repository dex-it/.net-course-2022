using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services.Exceptions;

namespace Services
{
    public class ClientService
    {
        public void AddClient(Client client)
        {
            if (client.PasportNum ==0)
            { 
                throw new ClientNoPasportData("У клиента нет паспортных данных"); }    
                
            if (DateTime.Now.Year - client.BirtDate.Year < 18)
            {
                throw new ClientUnder18Exception("Клиент меньше 18 лет");
            }
        }
    }
}
