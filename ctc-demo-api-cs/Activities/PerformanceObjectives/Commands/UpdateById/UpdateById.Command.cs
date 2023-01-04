using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.PerformanceObjectives.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.UpdateById;

public class Command : IRequest<SingleResponse<Response>>
{
    [FromRoute(Name = "id")] public string Id { get; set; }
    [FromBody] public UpdateEvalObjDto UpdateEvalObjDto { get; set; }
}
