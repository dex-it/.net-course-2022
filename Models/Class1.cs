namespace Models
{
    public class Person
    {
        public int id_pas { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
    }

    public class Emploeyy : Person
    {
        public int id { get; set; }
        public string contract { get; set; }

        public Emploeyy(int id, string contract)
        {
            this.id = id;
            this.contract = contract;
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