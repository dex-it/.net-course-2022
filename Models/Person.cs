using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Passport { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(string firstName, string lastName, string patronymic, int passport, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Patronymic = patronymic;
            Passport = passport;
            BirthDate = birthDate;
        }
    }
}
