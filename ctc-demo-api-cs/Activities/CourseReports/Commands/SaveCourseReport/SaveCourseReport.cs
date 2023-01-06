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

namespace WYWM.CTC.API.Activities.CourseReports.Commands.SaveCourseReport;

[Route(Routes.CourseReports)]
public class SaveCourseReport : EndpointBaseAsync.WithRequest<Command>.WithActionResult<SingleResponse<Response>>
{
    private readonly IMediator _mediator;

    public SaveCourseReport(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "SaveCourseReport",
        Description = "SaveCourseReport",
        OperationId = "7eade9a1-e699-48f9-9d15-611c66997a7b",
        Tags = new[] { Routes.CourseReports })
    ]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public override async Task<ActionResult<SingleResponse<Response>>> HandleAsync([FromRoute] Command request, 
        CancellationToken cancellationToken = new())
    {
        var result = await _mediator.Send(request, cancellationToken);
        
        if (result.IsValid)
            return new CreatedResult(new Uri(Routes.CourseReports, UriKind.Relative), new { result.Item });

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
