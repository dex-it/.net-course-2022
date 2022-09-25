using ModelsDb;
using Models;

namespace Services.Storage
{
    public interface IClientStorage : IStorage<ClientDb>
    {
        public void AddAccount(AccountDb account);
        public void RemoveAccount(AccountDb account);
        public void UpdateAccount(AccountDb account);
        public DbBank Data { get; }
    }
}