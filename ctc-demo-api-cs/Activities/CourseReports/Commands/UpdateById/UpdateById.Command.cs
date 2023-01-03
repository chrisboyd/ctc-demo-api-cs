using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Command : IRequest<SingleResponse<Response>>
{
    [FromRoute(Name = "id")] public string Id { get; set; }
    [FromBody] public UpdatePerfObjDto updatePerfObjDto { get; set; }
}
