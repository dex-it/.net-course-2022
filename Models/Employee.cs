using System;

namespace Models
{
    public class Employee : Person
    {
        public int Passport { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime BirthDate { get; set; }
        public string Contract { get; set; }


        public Employee(string firstName, string lastName, string patronymic, int passport, DateTime birthDate) : base(firstName, lastName, patronymic, passport, birthDate)
        {
        }

        public Employee()
        {
        }
    }
}
