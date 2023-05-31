using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OOP.Domain.DataBaseSettings;
using OOP.Domain.Models;
using OOP.Service.ICustomServices;
using Serializer;

namespace OOP.Service.CustomServices;

public class UserService<T> : ICustomService<T> where T: User
{
    private readonly IMongoCollection<T> _userCollection;

    public UserService(IOptions<UserDatabaseSettings> userDatabaseSettings)
    {
        var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
        
        _userCollection = mongoDatabase.GetCollection<T>(userDatabaseSettings.Value.UserCollectionName);
    }

    public async Task<List<T>> GetAllAsync()
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        return await _userCollection.Find(_ => true).ToListAsync();
    }

    public async Task<List<T>> GetByFilter(Expression<Func<T, bool>> filter)
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        return await _userCollection.Find(filter).ToListAsync();
    }

    public async Task<T> GetAsync(string id)
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        return await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task InsertAsync(T entity)
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        await _userCollection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, T entity)
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        await _userCollection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task RemoveAsync(string id) 
    {
        var jsonString = await SerializerJson.Serialize(await _userCollection.Find(_ => true).ToListAsync());
        await _userCollection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<long> Count() =>
        await _userCollection.CountDocumentsAsync("{}");
}