namespace WYWM.CTC.API.Activities.CourseReports.Commands.SaveCourseReport;

public class Response
{
    public string InstructorEmail { get; set; } = null!;
    public string StudentEmail { get; set; } = null!;
    public double Grade { get; set; }
    public string PerformanceObjectiveName { get; set; } = null!;
    public string ResultsId { get; set; } = null!;
}
