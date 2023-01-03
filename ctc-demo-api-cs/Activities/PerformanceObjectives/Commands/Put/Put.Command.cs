using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Put;

public class Command : IRequest<SingleResponse<Response>>
{
   [FromRoute(Name = "id")] public Guid Id { get; set; }
   [FromBody] public Domain Domain { get; set; }
}


