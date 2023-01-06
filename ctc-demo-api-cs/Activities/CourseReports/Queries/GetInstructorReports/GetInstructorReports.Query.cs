using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetInstructorReports;

public class Query : IRequest<ListResponse<Response>>
{
    [FromQuery(Name = "instructor")] public string InstructorEmail { get; set; }
}


