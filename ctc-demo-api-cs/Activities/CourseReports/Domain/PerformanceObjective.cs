using MongoDB.Bson;

namespace WYWM.CTC.API.Activities.CourseReports.Domain;

public class PerformanceObjective
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    public BsonObjectId Id { get; set; }

    public string Name { get; set; } = null!;
}