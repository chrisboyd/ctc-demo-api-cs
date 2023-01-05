using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Threenine.ApiResponse;
using WYWM.CTC.API.Activities.PerformanceObjectives.Services;

namespace WYWM.CTC.API.Activities.PerformanceObjectives.Queries.GetById;

public class Handler : IRequestHandler<Query, SingleResponse<Response>>
{
    private readonly IPerfObjectiveRepository _repository;
    private readonly IMapper _mapper;

    public Handler(IPerfObjectiveRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<SingleResponse<Response>> Handle(Query request, CancellationToken cancellationToken)
    {
        var perfObjective = await _repository.FindByIdAsync(request.Id);
        
        return new SingleResponse<Response>(_mapper.Map<Response>(perfObjective));
    }
}
