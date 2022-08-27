namespace Models
{
    public class Person
    {
        public string name { get; set; }
        public DateTime Data { get; set; }
        public int NumPasport { get; set; }
        public Person( string name, DateTime data, int numPasport)
        {
            this.name = name;
            Data = data;
            NumPasport = numPasport;
        }
    }
}