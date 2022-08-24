using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string firstName { get; set; }   
        public string lastName { get; set; }
        public int seriesOfPassport { get; set; }
        public int phoneNumber  { get; set; }
        public DateTime dateOfBirth { get; set; }    

    }
}
