using System.Linq;
using System.Threading.Tasks;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Infrastructure;

public static class CourseReportsDbInitializer
{
    public static async Task Initialize(CourseReportContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (context.CourseReports.Any())
        {
            return;
        }

        var courseReports = new CourseReport[]
        {
            new()
            {
                Grade = .55,
                InstructorEmail = "someone@demo.com",
                StudentEmail = "someoneelse@demo.com",
                PerformanceObjectiveName = "CTC-Default-PO",
                ResultsId = "63b4d3a00cdb0fe8129b4831"
            },
            new()
            {
                Grade = .75,
                InstructorEmail = "someone@demo.com",
                StudentEmail = "thirdperson@demo.com",
                PerformanceObjectiveName = "CTC-Default-PO",
                ResultsId = "63b4d3a00cdb0fe8129b4831"
            }
        };

        foreach (var report in courseReports)
        {
            context.CourseReports.Add(report);
        }

        await context.SaveChangesAsync();
    }
}