namespace Models
{
    public class Person
    {
        
        public string fname { get; set; }
        public string l_name { get; set; }

        public Person(string fname,string l_name)
        {
            
            this.fname = fname;
            this.l_name = l_name;
        }   
    }

    public  class Employee : Person
    {
        public int id { get; set; }

        public Employee(string fname, string l_name,int id) : base(fname,l_name)
        {
            this.id = id;
        }
        


            public static string updEmp(string fname,string l_name)
        {
            return ($"Name:{fname}\nSurname:{l_name}\nContract term:2 years");
        }
    }

    public class Client
    {

    }

    public struct Currency
    {
        public int CurName { get; set; }
        public string Name { get; set; }

    }
}