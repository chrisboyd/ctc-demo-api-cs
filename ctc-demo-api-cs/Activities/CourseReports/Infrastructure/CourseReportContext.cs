using Microsoft.EntityFrameworkCore;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Infrastructure;

public class CourseReportContext : DbContext
{
    public DbSet<CourseReport> CourseReports { get; set; }

    public CourseReportContext(DbContextOptions<CourseReportContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
    //     modelBuilder.Entity<CourseReport>().HasData(
    //         new CourseReport
    //         {
    //             Id = 1,
    //             Grade = .55,
    //             InstructorEmail = "someone@demo.com",
    //             StudentEmail = "someoneelse@demo.com",
    //             PerformanceObjectiveName = "CTC-Default-PO",
    //             ResultsId = "63b4d3a00cdb0fe8129b4831"
    //         });
    // }
}