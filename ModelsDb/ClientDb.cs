using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDb
{
    [Table(name: "clients")]
    public class ClientDb
    {
        [Column (name:"id")]
        public Guid Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "age")]
        public int Age { get; set; }

        [Column(name: "pasport_num")]
        public int PasportNum { get; set; }
    }
}