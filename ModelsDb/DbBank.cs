using Microsoft.EntityFrameworkCore;
using ModelsDb;


namespace ModelsDb
{
    public class DbBank: DbContext
    {
        public DbSet<ClientDb> clients { get; set; }
        public DbSet<EmployeeDb> employees { get; set; }
        public DbSet<AccountDb> accounts { get; set; }
        public DbBank()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
            "Host=localhost;Port = 1234;Database = bankdb; Username = postgres;Password = 0000"
        );
        }
    }
}
