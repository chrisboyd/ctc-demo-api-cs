using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Command : IRequest<SingleResponse<Response>>
{
    [FromBody] public PerformanceObjective PerformanceObjective { get; set; }
}


