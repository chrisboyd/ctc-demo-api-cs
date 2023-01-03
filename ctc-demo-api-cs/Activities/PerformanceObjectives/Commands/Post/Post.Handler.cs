using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Threenine;
using Threenine.ApiResponse;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Commands.Post;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDataService<> _services;

    public Handler(IDataService<Model> services)
    {
        _services = services;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        return await _services.Create<Domain, Response>(request.Domain);
    }
}
