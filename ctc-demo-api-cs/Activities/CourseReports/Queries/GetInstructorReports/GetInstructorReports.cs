using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.CourseReports.Queries.GetInstructorReports;

[Route(Routes.CourseReports)]
public class GetInstructorReports : EndpointBaseAsync.WithRequest<Query>.WithActionResult<ListResponse<Response>>
{
    private readonly IMediator _mediator;

    public GetInstructorReports(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    [HttpGet]
    [SwaggerOperation(
        Summary = "GetInstructorReports",
        Description = "GetInstructorReports",
        OperationId = "5eb91364-025e-4670-8c91-1f69e725b49b",
        Tags = new[] { Routes.CourseReports})
    ]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response))]
    [ProducesErrorResponseType(typeof(BadRequestObjectResult))]
    public override async Task<ActionResult<ListResponse<Response>>> HandleAsync([FromQuery] Query request, CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);
       
        if (result.IsValid)
            return new OkObjectResult(result.Items);
        
        return await HandleErrors(result.Errors);
    }
    
    private Task<ActionResult> HandleErrors(List<KeyValuePair<string, string[]>> errors)
    {
        ActionResult result = null;
        errors.ForEach(error =>
        {
            result = error.Key switch
            {
                ErrorKeyNames.Conflict => new ConflictResult(),
                _ => new BadRequestObjectResult(errors)
            };
        });
        return Task.FromResult(result);
    }
}
