using UAS_DRWA.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UAS_DRWA.Services;

public class KelasService
{
    private readonly IMongoCollection<Kelas> _kelasCollection;

    public KelasService(
        IOptions<UASDrwaDatabaseSettings> uasDrwaDatabaseSettings)
    {
 
        var mongoClient = new MongoClient(
            uasDrwaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            uasDrwaDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<Kelas>(
            uasDrwaDatabaseSettings.Value.KelasCollectionName);
    }

    public async Task<List<Kelas>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<Kelas?> GetAsync(string Id) =>
        await _kelasCollection.Find(x => x.Id == Id).FirstOrDefaultAsync();

    public async Task CreateAsync(Kelas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string Id, Kelas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.Id == Id, updatedKelas);

    public async Task RemoveAsync(string Id) =>
        await _kelasCollection.DeleteOneAsync(x => x.Id == Id);
}