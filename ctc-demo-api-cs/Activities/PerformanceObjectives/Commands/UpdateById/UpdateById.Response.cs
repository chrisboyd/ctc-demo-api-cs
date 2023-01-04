namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.UpdateById;

public class Response
{
    public string Name { get; set; } = null!;
    public bool Passed { get; set; }
    public string? Comments { get; set; }
}
