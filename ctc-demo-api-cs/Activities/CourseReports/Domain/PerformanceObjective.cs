using MongoDB.Bson;

namespace WYWM.CTC.API.Activities.CourseReports.Domain;

public class PerformanceObjective
{
    // [BsonId]
    // [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    public string PoName { get; set; } = null!;
}