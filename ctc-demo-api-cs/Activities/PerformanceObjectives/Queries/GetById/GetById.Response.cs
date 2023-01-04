
using System.Collections.Generic;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Response
{
   public string Id { get; set; } = null!;
   public string Name { get; set; } = null!;
   public List<EvaluationObjective>? EvaluationObjectives { get; set; }
}
