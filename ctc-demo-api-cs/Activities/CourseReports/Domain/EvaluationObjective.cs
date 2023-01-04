using MongoDB.Bson;

namespace WYWM.CTC.API.Activities.CourseReports.Domain;

public class EvaluationObjective
{
    public BsonObjectId Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public bool Passed { get; set; }
}