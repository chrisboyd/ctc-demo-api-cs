using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetbyId;

public class Query : IRequest<SingleResponse<Response>>
{
    [FromRoute(Name = "id")] public Guid Id { get; set; }  
}


