using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.PerformanceObjectives.Services;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetById;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly IDbClient _client;
    private readonly IMapper _mapper;

    public Handler(IDbClient client,IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var perfObjective = await _client.FindByIdAsync(request.Id);
        
        return new SingleResponse<Response>(_mapper.Map<Response>(perfObjective));
    }
}
