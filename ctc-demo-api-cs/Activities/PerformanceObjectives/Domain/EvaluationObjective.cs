namespace WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

public class EvaluationObjective
{
    public string Name { get; set; } = null!;
    public bool Passed { get; set; }
    public string? Comments { get; set; }
}