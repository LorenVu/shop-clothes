using MongoDB.Driver;

namespace BuildingBlock.Shared.Contracts.Domains.Interfaces;

public interface IMongoDbRepositoryBase <T> where T : MongoEntity
{
    IMongoCollection<T> FindAll(ReadPreference? prefernce = null);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(string id);
}