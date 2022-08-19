using System;

namespace Models
{
    public class Employee : Person
    {
        public string Contract { get; set; }


        public Employee(string firstName, string lastName, string patronymic, int passport, DateTime birthDate) : base(firstName, lastName, patronymic, passport, birthDate)
        {
        }

        public Employee()
        {
        }
    }
}
