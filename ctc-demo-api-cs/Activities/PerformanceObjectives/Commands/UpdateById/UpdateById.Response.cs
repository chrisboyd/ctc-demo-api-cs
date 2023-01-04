using System.Collections.Generic;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Response
{
    public string Name { get; set; } = null!;
    public bool Passed { get; set; }
    public string? Comments { get; set; }
}
