using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Activities.CourseReports.Infrastructure;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public class MongoDbClient : IMongoDbClient
{
    public IMongoCollection<PerformanceObjective> PoCollection;

    public MongoDbClient(IOptions<MongoDbSettings> mongoDbSettings)
    {
        var client = new MongoClient(mongoDbSettings.Value.ConnectionUri);
        var database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        PoCollection = database.GetCollection<PerformanceObjective>(mongoDbSettings.Value.CollectionName);
    }
    
}