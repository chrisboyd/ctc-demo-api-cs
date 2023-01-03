using System;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Patch;

public class Command : IRequest<SingleResponse<Response>>
{
        [FromRoute(Name = "id")] public Guid  Id { get; set; }
        [FromBody]  public JsonPatchDocument<PerformanceObjective> Domain { get; set; }
}

