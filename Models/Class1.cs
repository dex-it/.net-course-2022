namespace Models
{
    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int passport_id { get; set; }
        public DateTime birthday { get; set; }

    }

    public class Employee : Person
    {
        public string contract { get; set; }
        public string company { get; set; }
        public string position { get; set; }
        public int salary { get; set; }
    }

    public class Client : Person
    {
        public int account_number { get; set; }
        public int account_value { get; set; }

    }


    public struct Currency
    {
        public string value { get; set; }
        public int code { get; set; }

    }
}