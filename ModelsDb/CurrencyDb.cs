using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsDb
{
    [Table(name: "currencies")]
    public class CurrencyDb
    {
        [Key]
        [Column(name: "currence_id")]
        public Guid Id { get; set; }

        [Column(name: "name")]
        public string Name { get; set; }

        [Column(name: "code")]
        public int Code { get; set; }

        [Column(name: "account")]
        public AccountDb Account { get; set; }

        [Column(name: "account_id")]
        public Guid AccountId { get; set; }
    }
}
