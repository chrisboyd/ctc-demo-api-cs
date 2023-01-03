using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Driver;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.CourseReports.Domain;
using WYWM.CTC.API.Activities.CourseReports.Services;

namespace WYWM.CTC.API.Activities.CourseReports.Commands.UpdateById;

public class Handler : IRequestHandler<Command, SingleResponse<Response>>
{
    private readonly IDbClient _client;
    private readonly IMapper _mapper;

    public Handler(IDbClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Command request, CancellationToken cancellationToken)
    {
        await _client.UpdateByIdAsync(request.PerformanceObjective);
        return new SingleResponse<Response>(_mapper.Map<Response>(request.PerformanceObjective));
    }
}
