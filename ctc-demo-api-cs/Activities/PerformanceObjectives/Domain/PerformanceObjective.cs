using System.Collections.Generic;
using MongoDB.Bson;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

public class PerformanceObjective
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    public BsonObjectId Id { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public List<EvaluationObjective>? EvaluationObjectives { get; set; }
}