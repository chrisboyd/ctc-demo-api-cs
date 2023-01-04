using System.Collections.Generic;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetById;

public class Response
{
   public string Id { get; set; } = null!;
   public string Name { get; set; } = null!;
   public List<EvaluationObjective>? EvaluationObjectives { get; set; }
}
