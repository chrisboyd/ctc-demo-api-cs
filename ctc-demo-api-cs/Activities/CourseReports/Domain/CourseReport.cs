using System.ComponentModel.DataAnnotations.Schema;

namespace WYWM.CTC.API.Activities.CourseReports.Domain;

public class CourseReport
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; }
    public string InstructorEmail { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
    public double Grade { get; set; }
    public string PerformanceObjectiveName { get; set; } = null!;
    public string ResultsId { get; set; } = null!;
}