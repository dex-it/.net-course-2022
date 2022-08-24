using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Client : Person
    {
        public Client()
        {
        }

        public Client(string firstName, string lastName, string patronymic, int passport, DateTime birthDate) : base(firstName, lastName, patronymic, passport, birthDate)
        {
        }
    }
}
