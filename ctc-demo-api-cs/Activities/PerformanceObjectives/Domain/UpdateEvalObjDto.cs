
namespace WYWM.CTC.API.Activities.CourseReports.Domain;

public class UpdateEvalObjDto
{
    public string Name { get; set; } = null!;
    public bool? Passed { get; set; }
    public string? Comments { get; set; }
}