using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Exceptions;
using WYWM.CTC.API.Infrastructure;

namespace WYWM.CTC.API.Activities.CourseReports.Services;

public class DbClient : IDbClient
{
    private readonly IMongoCollection<PerformanceObjective> _poCollection;

    public DbClient(IOptions<MongoDbSettings> mongoDbSettings)
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

    public async Task<bool> UpdateByIdAsync(string id, UpdatePerfObjDto updatePerfObjDto)
    {
        var updateFilter = Builders<PerformanceObjective>.Filter.Eq("_id", new ObjectId(id));
        var updateDefinition = Builders<PerformanceObjective>.Update
            .Set(x => x.Name, updatePerfObjDto.Name);
        var result = await _poCollection.UpdateOneAsync(updateFilter, updateDefinition);
        if (!result.IsAcknowledged)
        {
            throw new NotFoundException("Document not found", 
                $"Document with id: {id} could not be updated");
        }

        return result.IsAcknowledged;
    }
}