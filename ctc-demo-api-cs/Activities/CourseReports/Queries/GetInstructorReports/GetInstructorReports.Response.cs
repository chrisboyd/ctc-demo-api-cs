using System;
using System.Collections.Generic;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetInstructorReports;

public class Response
{
   public string InstructorEmail { get; set; } = null!;
   public string StudentEmail { get; set; } = null!;
   public double Grade { get; set; }
   public string PerformanceObjectiveName { get; set; } = null!;
   public string ResultsId { get; set; } = null!;
}
