using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Threenine;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Domain;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Patch;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService<PerformanceObjective> _services;

    public Handler(IDataService<PerformanceObjective> services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Patch<PerformanceObjective, Response>(x => x.Id == request.Id,
            request.Domain);
    }
}
