using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;
using WYWM.CTC.API.Activities.PerformanceObjectives.Infrastructure;
using WYWM.CTC.API.Exceptions;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Services;

public class PerfObjectiveRepository : IPerfObjectiveRepository
{
    private readonly IMongoCollection<PerformanceObjective> _poCollection;

    public PerfObjectiveRepository(IOptions<MongoDbSettings> mongoDbSettings)
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
        var resultCursor = await _poCollection.FindAsync(filter);
        
        var result = await resultCursor.FirstOrDefaultAsync();
        if (result is null)
        {
            throw new NotFoundException("Document not found", $"Document with id: {id} was not found");
        }
        
        return result;
    }

    public async Task<bool> UpdateByIdAsync(string id, UpdateEvalObjDto updateEvalObjDto)
    {
        // var updateFilter = Builders<PerformanceObjective>.Filter.Eq("_id", new ObjectId(id));
        // var updateDefinition = Builders<PerformanceObjective>.Update
        //     .Set(x => x.Name, updateEvalObjDto.Name);
        // var result = await _poCollection.UpdateOneAsync(updateFilter, updateDefinition);
        // if (result.IsAcknowledged && result.ModifiedCount == 0)
        // {
        //     throw new NotFoundException("Document not found", 
        //         $"Document with id: {id} could not be found");
        // }
        //
        // return result.IsAcknowledged;
        
        var arrayFilter = Builders<PerformanceObjective>.Filter.Eq("_id", new ObjectId(id))
                          & Builders<PerformanceObjective>.Filter.Eq("EvaluationObjectives.Name",
                              updateEvalObjDto.Name);
        var arrayUpdate = Builders<PerformanceObjective>.Update
            .Set("EvaluationObjectives.$.Passed", updateEvalObjDto.Passed)
            .Set("EvaluationObjectives.$.Comments", updateEvalObjDto.Comments);
        var updateResult = await _poCollection.UpdateOneAsync(arrayFilter, arrayUpdate);

        if (updateResult.IsModifiedCountAvailable && updateResult.ModifiedCount == 0)
        {
            throw new NotFoundException("Document not found", 
            $"Document with id: {id} and EO: {updateEvalObjDto.Name} could not be found");
        }
        return true;
    }
}