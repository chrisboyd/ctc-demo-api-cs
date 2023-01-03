using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetById;

public class Query : IRequest<SingleResponse<Response>>
{
    [FromRoute(Name = "id")] public string Id { get; set; }
}


