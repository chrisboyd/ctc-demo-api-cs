
namespace WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

public class UpdateEvalObjDto
{
    public string Name { get; set; } = null!;
    public bool? Passed { get; set; }
    public string? Comments { get; set; }
}