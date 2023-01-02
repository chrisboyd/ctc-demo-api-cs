using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Activities.CourseReports.Infrastructure;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public class MongoDbClient : IMongoDbClient
{
    private readonly IMongoCollection<PerformanceObjective> _poCollection;

    public MongoDbClient(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _poCollection = database.GetCollection<PerformanceObjective>(mongoDbSettings.Value.CollectionName);
    }

    public async Task<List<PerformanceObjective>> GetAsync()
    {
        return await _poCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task<PerformanceObjective> FindByIdAsync(string id)
    {
        var filter = Builders<PerformanceObjective>.Filter.Eq(x => x.Id, new ObjectId(id));
        var result = await _poCollection.FindAsync(filter);
        return await result.FirstOrDefaultAsync();
    }
}