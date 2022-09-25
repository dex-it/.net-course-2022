using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDb
{
    [Table (name:"accounts")]
    public class AccountDb
    {
        [Column(name: "id")]
        public Guid Id { get; set; }

        [Column(name: "currency")]
        public string Currency { get; set; }

        [Column(name: "amount")]
        public int Amount { get; set; }

    }
}
