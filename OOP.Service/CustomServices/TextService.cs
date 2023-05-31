using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OOP.Domain.DataBaseSettings;
using OOP.Domain.Models;
using OOP.Service.ICustomServices;

namespace OOP.Service.CustomServices;

public class TextService<T> : ICustomService<T> where T: PrintableText
{
    private readonly IMongoCollection<T> _textCollection;

    public TextService(IOptions<TextDatabaseSettings> textDatabaseSettings)
    {
        var mongoClient = new MongoClient(textDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(textDatabaseSettings.Value.DatabaseName);
        
        _textCollection = mongoDatabase.GetCollection<T>(textDatabaseSettings.Value.TextCollectionName);
    }

    public async Task<List<T>> GetAllAsync() =>
        await _textCollection.Find(_ => true).ToListAsync();

    public async Task<List<T>> GetByFilter(Expression<Func<T,bool>> filter) => 
        await _textCollection.Find(filter).ToListAsync();

    public async Task<T> GetAsync(string id) =>
        await _textCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task InsertAsync(T entity) =>
        await _textCollection.InsertOneAsync(entity);

    public async Task UpdateAsync(string id, T entity) =>
        await _textCollection.ReplaceOneAsync(x => x.Id == id, entity);

    public async Task RemoveAsync(string id) =>
        await _textCollection.DeleteOneAsync(x => x.Id == id);
    
    public async Task<long> Count() =>
        await _textCollection.CountDocumentsAsync("{}");
}