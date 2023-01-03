using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetAll;

public class Query : IRequest<SingleResponse<Response>>
{
   [FromRoute]  public Guid Id { get; set; }   
}


